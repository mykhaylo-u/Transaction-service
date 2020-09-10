using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using transaction_service.domain.Dto;
using transaction_service.domain.Interfaces;
using transaction_service.services.Helpers;
using transaction_service.web.Models;

namespace file_uploader.web.Controllers
{
    public class FileUploadController : Controller
    {
        private readonly ILogger<FileUploadController> _logger;
        private readonly IFileUploader _fileUploader;


        public FileUploadController(IFileUploader fileUploader, ILogger<FileUploadController> logger)
        {
            _fileUploader = fileUploader;
            _logger = logger;
        }

        // GET: /<controller>/
        /// <summary>
        /// Index page for uploading files
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View("Index");
        }

        /// <summary>
        /// Upload file with transactions
        /// </summary>
        /// <param name="fileViewModel"></param>
        /// <returns></returns>
        [HttpPost("fileUpload")]
        public async Task<IActionResult> FileUploadAsync(FileViewModel fileViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", fileViewModel);
            }

            try
            {
                await using var memoryStream = new MemoryStream();
                await fileViewModel.File.CopyToAsync(memoryStream);

                var file = new FileDto
                {
                    FileName = Path.GetFileName(fileViewModel.File.FileName),
                    Extension = FileExtensionHelper.GetFileExtension(fileViewModel.File.FileName),
                };

                await _fileUploader.UploadFileAsync(file, memoryStream);

                TempData["IsSuccess"] = "File has been uploaded successfully.";
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                fileViewModel.Exception = e;
                ModelState.AddModelError("Exception", $"Internal server error. {e.Message}");
            }

            return View("Index", fileViewModel);
        }
    }
}