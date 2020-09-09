using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using transaction_service.web.Models.Validation;

namespace transaction_service.web.Models
{
    public class FileViewModel : BaseViewModel
    {
        [Required]
        [MaxFileSize(1 * 1024 * 1024, ErrorMessage = "File size should not overrun {0} bytes")]
        [AllowedFileExtensionsAttribute(new[] { ".csv", ".xml" }, ErrorMessage = "Unknown file. Please select {0} file")]
        public IFormFile File { get; set; }
    }
}
