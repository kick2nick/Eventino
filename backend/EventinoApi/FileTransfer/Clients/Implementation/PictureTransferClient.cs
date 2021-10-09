using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using FileTransfer.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FileTransfer.Clients.Implementation
{
    internal class PictureTransferClient : IPictureTransferClient
    {
        private const int TransferOptionsMaxConcurrency = 8;
        private const int TransferOptionsMaxSize = 50 * 1024 * 1024;
        private const string JpgImageContentType = "image/jpg";
        private const string BlobContainerNameDevelopment = "pictures-dev";
        private const string BlobContainerNameProduction = "pictures-prod";

        private readonly ILogger<PictureTransferClient> _logger;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _blobContainerName;

        private BlobContainerClient PicturesContainerClient { get => _blobServiceClient.GetBlobContainerClient(_blobContainerName); }
        private static BlobUploadOptions UploadOptions
        {
            get => new()
            {
                TransferOptions = new StorageTransferOptions
                {
                    MaximumConcurrency = TransferOptionsMaxConcurrency,
                    MaximumTransferSize = TransferOptionsMaxSize,
                },
                HttpHeaders = new BlobHttpHeaders
                {
                    ContentType = JpgImageContentType,
                }
            };
        }

        public PictureTransferClient(ILogger<PictureTransferClient> logger,
            BlobServiceClient blobServiceClient)
        {
            _logger = logger;
            _blobServiceClient = blobServiceClient;

            _blobContainerName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") switch
            {
                "Development" => BlobContainerNameDevelopment,
                "Production" => BlobContainerNameProduction,
                _ => throw new FileTransferConfigurationException("ASPNETCORE_ENVIRONMENT variable has unknown value"),
            };

            if (!PicturesContainerClient.Exists())
            {
                PicturesContainerClient.CreateIfNotExists();
            }
        }

        public async Task<byte[]> DownloadFileAsync(string fileName)
        {
            var blob = PicturesContainerClient.GetBlobClient(fileName);
            await using var memoryStream = new MemoryStream();
            var response = await blob.DownloadToAsync(memoryStream);

            if (response.Status is not (StatusCodes.Status200OK or StatusCodes.Status206PartialContent))
            {
                var errorMessage = $"Failed to download file {fileName} from blob storage. Response: {response.ReasonPhrase}";
                _logger.LogError(errorMessage);
                throw new FileTransferResponseException(errorMessage);
            }

            return memoryStream.ToArray();
        }

        public async Task UploadFileAsync(string fileName, Stream data)
        {
            var blobClient = PicturesContainerClient.GetBlobClient(fileName);

            data.Position = 0;

            var response = await blobClient.UploadAsync(data, UploadOptions);

            if (response.GetRawResponse().Status != StatusCodes.Status201Created)
            {
                var errorMessage = $"Failed to upload file {fileName} to blob storage. Response: {response.GetRawResponse().ReasonPhrase}";
                _logger.LogError(errorMessage);
                throw new FileTransferResponseException(errorMessage);
            }
        }

        public async Task UpdateFileAsync(string fileName, Stream data)
        {
            var blobClient = PicturesContainerClient.GetBlobClient(fileName);
            if (!blobClient.Exists())
            {
                string errorMessage = $"Failed to update file {fileName} in blob storage. No blob with such name found";
                _logger.LogError(errorMessage);
                throw new FileTransferException(errorMessage);
            }

            data.Position = 0;

            var response = await blobClient.UploadAsync(data, UploadOptions);

            if (response.GetRawResponse().Status != StatusCodes.Status201Created)
            {
                var errorMessage = $"Failed to update file {fileName} to blob storage. Response: {response.GetRawResponse().ReasonPhrase}";
                _logger.LogError(errorMessage);
                throw new FileTransferResponseException(errorMessage);
            }
        }

        public async Task DeleteFileAsync(string fileName)
        {
            var blob = PicturesContainerClient.GetBlobClient(fileName);

            var response = await blob.DeleteIfExistsAsync();
            if (!response.Value)
            {
                var errorMessage = $"Failed to delete file {fileName} from blob storage. Response: {response.GetRawResponse().ReasonPhrase}";
                _logger.LogError(errorMessage);
                throw new FileTransferResponseException(errorMessage);
            }
        }
    }
}
