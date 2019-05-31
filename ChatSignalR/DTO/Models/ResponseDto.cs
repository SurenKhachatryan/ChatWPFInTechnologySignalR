using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Models
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public bool HasError { get; set; }
        public List<ErrorModelDto> Errors { get; set; }
    }
}
