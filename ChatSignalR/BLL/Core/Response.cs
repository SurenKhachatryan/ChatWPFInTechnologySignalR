using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Core
{
    class Response<T>
    {
        public T Data { get; set; }
        public bool HasError { get; set; }
        public List<ErrorModel> Errors { get; set; }

    }
}
