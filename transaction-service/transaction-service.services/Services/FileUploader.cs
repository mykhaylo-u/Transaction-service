using System.Threading.Tasks;
using transaction_service.domain.Interfaces;
using transaction_service.domain.Dto;
using Microsoft.Extensions.Logging;

namespace transaction_service.services.Services
{
    public class FileUploader : IFileUploader
    {
        private readonly ILogger<FileUploader> _logger;

        public FileUploader(ILogger<FileUploader> logger)
        {
            _logger = logger;
        }

        public async Task<bool> UploadFile(FileDto file)
        {

            //TODO: create a proper parser 
            //      parse file
            //      save data to db
            return true;
        }
    }
}
