using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Core;
using BLL.DomainModels;

namespace BLL.Services.FileManagmentServices
{
    public class FileServices : IFileServices
    {
        private string rootPath = "D:\\";

        public void DeleteFile(BaseFileInfo baseFile)
        {

        }

        public List<string> GetFileUrls(BaseFileInfo fileInfo)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UploadFile(FileRequest addFile)
        {
            var extension = GetFileExtension(addFile.File.ContentType);

            var filePath = Path.Combine(rootPath, Guid.NewGuid().ToString("N") + "." + extension);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await addFile.File.CopyToAsync(stream);
            }

            return "";
        }



        public Task<List<string>> UploadFiles(FilesRequest addFiles)
        {
            throw new NotImplementedException();
        }

        private string GetFileExtension(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new AppException(1);
            }

            if (fileName.Split('/').Count() < 2)
            {
                throw new AppException(1);
            }

            return fileName.Split('/').Last();
        }
    }
}
