﻿using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class AppSettings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
