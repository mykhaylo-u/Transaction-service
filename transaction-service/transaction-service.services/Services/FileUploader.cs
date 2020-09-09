using System.Threading.Tasks;
using transaction_service.domain.Interfaces;
using transaction_service.domain.Dto;
using Microsoft.Extensions.Logging;
using System;
using transaction_service.database;
using transaction_service.domain.ErrorHandling;

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

        public async Task<bool> UploadFile(FileDto file)
        {
            var fileParser = _fileParserFactory.CreateParser(file.Extension);
            try
            {
                await foreach (var trans in fileParser.ReadFile(file))
                {
                    await _dbContext.AddAsync(trans);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Invalid file.");
                throw new FileReadingException(e);
            }
            return true;
        }
    }
}
