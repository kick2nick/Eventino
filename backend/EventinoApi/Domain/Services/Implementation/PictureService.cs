using FileTransfer.Clients;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Domain.Services.Implementation
{
    public class PictureService : IPictureService
    {
        private readonly ILogger<PictureService> _logger;
        private readonly IPictureTransferClient _pictureTransferClient;

        public PictureService(ILogger<PictureService> logger,
            IPictureTransferClient pictureTransferClient)
        {
            _logger = logger;
            _pictureTransferClient = pictureTransferClient;
        }

        public Task DeleteFileAsync(string fileName)
        {
            _ = fileName ?? throw new ArgumentNullException(nameof(fileName));

            return _pictureTransferClient.DeleteFileAsync(fileName);
        }

        public Task<byte[]> DownloadFileAsync(string fileName)
        {
            _ = fileName ?? throw new ArgumentNullException(nameof(fileName));

            return _pictureTransferClient.DownloadFileAsync(fileName);
        }

        public Task UpdateFileAsync(string fileName, Stream data)
        {
            _ = fileName ?? throw new ArgumentNullException(nameof(fileName));
            _ = data ?? throw new ArgumentNullException(nameof(data));
            
            return _pictureTransferClient.UpdateFileAsync(fileName, data);
        }

        public async Task<string> UploadFileAsync(string fileName, Stream data)
        {
            _ = fileName ?? throw new ArgumentNullException(nameof(fileName));
            _ = data ?? throw new ArgumentNullException(nameof(data));

            var blobName = $"{Guid.NewGuid()}{Path.GetExtension(fileName).ToLower()}";

            await _pictureTransferClient.UploadFileAsync(blobName, data);

            return blobName;
        }
    }
}
