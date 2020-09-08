using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using transaction_service.web.Models;

namespace file_uploader.web.Controllers
{
    public class FileUploadController : Controller
    {
        private readonly ILogger<FileUploadController> _logger;

        public FileUploadController(ILogger<FileUploadController> logger)
        {
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
        public IActionResult FileUpload(FileViewModel fileViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", fileViewModel);
            }

            try
            {
               //TODO : proceed with upload file process

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