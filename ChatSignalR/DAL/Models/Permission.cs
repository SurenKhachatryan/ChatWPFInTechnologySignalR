using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Permission
    {
        public Permission()
        {
            RolePermission = new HashSet<RolePermission>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Action { get; set; }

        public virtual ICollection<RolePermission> RolePermission { get; set; }
    }
}
