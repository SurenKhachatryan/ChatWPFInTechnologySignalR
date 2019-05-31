using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class UserSession
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Token { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }

        public virtual User User { get; set; }
    }
}
