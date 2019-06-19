using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BLL.DomainModels;

namespace BLL.Services.FileManagmentServices
{
    public class FileServices : IFileServices
    {
        public void DeleteFile(BaseFileInfo baseFile)
        {
            throw new NotImplementedException();
        }

        public List<string> GetFileUrls(BaseFileInfo fileInfo)
        {
            throw new NotImplementedException();
        }

        public Task<string> UploadFile(FileRequest addFile)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> UploadFiles(FilesRequest addFiles)
        {
            throw new NotImplementedException();
        }
    }
}
