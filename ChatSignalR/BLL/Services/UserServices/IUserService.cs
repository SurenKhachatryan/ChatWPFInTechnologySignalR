using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Services.UserServices
{
    public interface IUserService
    {
        Task<List<UserSession>> GetUserSessions(int userId);
        Task<UserSession> Login(User user);
        Task logOut();
        Task<User> Registration(User user);
        Task UpdateUserSessionDate(string token);
    }
}