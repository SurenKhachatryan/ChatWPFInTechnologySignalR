using System.Collections.Generic;

namespace BLL.Core
{
    public class PagedModel<T>
    {
        public List<T> Entities { get; set; }
        public int Count { get; set; }
        public Dictionary<string, string> AdditionalInfo { get; set; }

    }
}
