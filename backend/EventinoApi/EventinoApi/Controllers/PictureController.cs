using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace EventinoApi.Controllers
{
    [Route("api/pictures")]
    [Controller]
    public class PictureController : Controller
    {
        private readonly IPictureService _pictureService;

        public PictureController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFileAsync(IFormFileCollection files)
        {
            if (files.Count != 1)
            {
                return BadRequest("Can only upload 1 file at a time using this endpoint");
            }

            using var dataStream = new MemoryStream();
            await files[0].CopyToAsync(dataStream);

            var fileName = await _pictureService.UploadFileAsync(files[0].FileName, dataStream);

            return Ok(fileName);
        }

        [HttpGet("{filePath}")]
        public async Task<IActionResult> GetFileByPathAsync(string filePath)
        {
            _ = filePath ?? throw new ArgumentNullException(nameof(filePath));
            filePath = filePath.ToLower().Replace("%2f", "/");

            var fileContents = await _pictureService.DownloadFileAsync(filePath);

            var contentType = $"image/{Path.GetExtension(filePath).ToLower()}";
            return File(fileContents, contentType);
        }

        [HttpDelete("{filePath}")]
        public async Task<IActionResult> DeleteFileByPathAsync(string filePath)
        {
            _ = filePath ?? throw new ArgumentNullException(nameof(filePath));
            filePath = filePath.ToLower().Replace("%2f", "/");

            try
            {
                await _pictureService.DeleteFileAsync(filePath);
            }
            catch (Exception)
            {
                return Forbid();
            }

            return Ok();
        }
    }
}
