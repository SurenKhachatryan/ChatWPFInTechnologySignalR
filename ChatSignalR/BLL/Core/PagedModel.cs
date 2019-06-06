using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Core
{
    class PagedModel<T>
    {
        public List<T> Entities { get; set; }
        public int Count { get; set; }
        public Dictionary<string, string> AdditionalInfo { get; set; }

    }
}
