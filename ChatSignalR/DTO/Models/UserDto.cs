using System;

namespace DTO.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
