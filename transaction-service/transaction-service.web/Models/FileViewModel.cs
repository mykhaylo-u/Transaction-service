using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace transaction_service.web.Models
{
    public class FileViewModel : BaseViewModel
    {
        [Required]
        public IFormFile File { get; set; }
    }
}
