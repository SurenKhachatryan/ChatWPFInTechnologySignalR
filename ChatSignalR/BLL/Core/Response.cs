using System.Collections.Generic;

namespace BLL.Core
{
    public class Response<T>
    {
        public T Data { get; set; }
        public bool HasError { get; set; }
        public List<ErrorModel> Errors { get; set; }

    }
}
