using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace BLL.DomainModels
{
    public class FilesRequest : BaseFileInfo
    {
        public List<IFormFile> Files { get; set; }
    }
}
