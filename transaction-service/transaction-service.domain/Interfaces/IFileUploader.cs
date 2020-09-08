using System.Threading.Tasks;
using transaction_service.domain.Dto;

namespace transaction_service.domain.Interfaces
{
    public interface IFileUploader
    {
        Task<bool> UploadFile(FileDto file);
    }
}
