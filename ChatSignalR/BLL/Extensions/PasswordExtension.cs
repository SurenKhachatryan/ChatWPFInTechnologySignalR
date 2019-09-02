using System;
using System.Text;

namespace BLL.Extensions
{
    public static class PasswordExtension
    {
        public static string CreatePasswordHash(this string password, string passwordHash)
        {

            using (var hmac = new System.Security.Cryptography.HMACSHA512(Encoding.UTF8.GetBytes(passwordHash)))
            {
                return Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}
