using Microsoft.AspNetCore.Http;

namespace BLL.DomainModels
{
    public class FileRequest : BaseFileInfo
    {
        public IFormFile File { get; set; }
    }
}
