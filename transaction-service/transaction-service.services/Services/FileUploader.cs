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

namespace transaction_service.services.Services
{
    public class FileUploader : IFileUploader
    {
        private readonly ILogger<FileUploader> _logger;
        private readonly IFileParserFactory _fileParserFactory;
        private readonly ITransactionDbContext _dbContext;

        public FileUploader(ILogger<FileUploader> logger, IFileParserFactory fileParserFactory, ITransactionDbContext dbContext)
        {
            _logger = logger;
            _fileParserFactory = fileParserFactory;
            _dbContext = dbContext;
        }

        public async Task<bool> UploadFile(FileDto file, MemoryStream memoryStream)
        {
            var fileParser = _fileParserFactory.CreateParser(file.Extension);
            try
            {
                var transactions = new List<Transaction>();

                await foreach (var trans in fileParser.ParseFromFile(memoryStream))
                {
                    transactions.Add(trans);
                }

                await _dbContext.AddRangeAsync(transactions);
            }
            catch (CsvFileParserException e)
            {
                _logger.LogError($"Invalid file. File name:{file.FileName}, message:{e.Message}");
                throw e;
            }
            catch (Exception e)
            {
                _logger.LogError("Invalid file.");
                throw e;
            }
            return true;
        }
    }
}
