using System.IO;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IPictureService
    {
        Task DeleteFileAsync(string fileName);
        Task<byte[]> DownloadFileAsync(string fileName);
        Task UpdateFileAsync(string fileName, Stream data);
        Task<string> UploadFileAsync(string fileName, Stream data);
    }
}
