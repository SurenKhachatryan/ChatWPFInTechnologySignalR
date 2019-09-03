namespace DTO.Models
{
    public class UserSessionDto
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string LoginName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
