using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Error
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Translation { get; set; }
    }
}
