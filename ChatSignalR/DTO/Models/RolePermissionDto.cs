using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Models
{
    class RolePermissionDto
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
    }
}
