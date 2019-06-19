using BLL.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services.FileManagmentServices
{
    public interface IFileServices
    {
        Task<string> UploadFile(FileRequest addFile);
        Task<List<string>> UploadFiles(FilesRequest addFiles);
        void DeleteFile(BaseFileInfo baseFile);
        List<string> GetFileUrls(BaseFileInfo fileInfo);
    }
}
