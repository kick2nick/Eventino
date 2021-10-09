using System.IO;
using System.Threading.Tasks;

namespace FileTransfer.Clients
{
    public interface IFileTransferClient
    {
        Task<byte[]> DownloadFileAsync(string fileName);
        Task UploadFileAsync(string fileName, Stream data);
        Task UpdateFileAsync(string fileName, Stream data);
        Task DeleteFileAsync(string fileName);
    }
}
