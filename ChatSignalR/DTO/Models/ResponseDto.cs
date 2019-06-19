using System.Collections.Generic;

namespace DTO.Models
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public bool HasError { get; set; }
        public List<ErrorModelDto> Errors { get; set; }
    }
}
