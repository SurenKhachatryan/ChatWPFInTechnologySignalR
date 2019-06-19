using System.Collections.Generic;

namespace BLL.DomainModels
{
    public class BaseFileInfo
    {
        public int? Id { get; set; }
        public string Method { get; set; }
        public string FileName { get; set; }
        public List<string> FileNames { get; set; }
    }
}
