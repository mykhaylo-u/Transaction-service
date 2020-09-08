using transaction_service.domain.Enums;

namespace transaction_service.domain.Dto
{
    public class FileDto
    {
        public string FileName { get; set; }
        public byte[] Content { get; set; }
        public FileExtension Extension { get; set; }
    }
}
