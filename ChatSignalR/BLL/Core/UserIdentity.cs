using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Core
{
    public class UserIdentity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }

}
