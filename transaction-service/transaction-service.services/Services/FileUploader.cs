using System.Threading.Tasks;
using transaction_service.domain.Interfaces;
using transaction_service.domain.Dto;
using Microsoft.Extensions.Logging;
using System;
using transaction_service.database;
using System.Collections.Generic;
using transaction_service.domain.Entities;
using System.IO;
using transaction_service.services.Services.CsvFileService.ErrorHandling;
using transaction_service.services.Services.XmlFileParsers.ErrorHandling;
using transaction_service.domain.ErrorHandling;

namespace transaction_service.services.Services
{
    public class FileUploader : IFileUploader
    {
        private readonly ILogger<FileUploader> _logger;
        private readonly IFileParserFactory _fileParserFactory;
        private readonly ITransactionsService _transactionsService;

        public FileUploader(ILogger<FileUploader> logger, IFileParserFactory fileParserFactory, ITransactionsService transactionsService)
        {
            _logger = logger;
            _fileParserFactory = fileParserFactory;
            _transactionsService = transactionsService;
        }

        public async Task UploadFileAsync(FileDto file, MemoryStream memoryStream)
        {
            var fileParser = _fileParserFactory.CreateParser(file.Extension);
            try
            {
                var transactions = new List<Transaction>();

                await foreach (var trans in fileParser.ParseFromFile(memoryStream))
                {
                    transactions.Add(trans);
                }

                await _transactionsService.AddTransactionRangeAsync(transactions);
            }
            catch (CsvFileParserException e)
            {
                _logger.LogError($"Csv file parsing failed. File name:{file.FileName}, message:{e.Message}");
                throw e;
            }
            catch (XmlFileParserExeption e)
            {
                _logger.LogError($"Xml file parsing failed. File name:{file.FileName}, message:{e.Message}");
                throw e;
            }
            catch (InvalidFileExtensionException e)
            {
                _logger.LogError($"Unknown file extension. File name:{file.FileName}, message:{e.Message}");
                throw e;
            }
            catch (Exception e)
            {
                _logger.LogError($"Internal server error. File name:{file.FileName}, message:{e.Message}");
                throw e;
            }
        }
    }
}
