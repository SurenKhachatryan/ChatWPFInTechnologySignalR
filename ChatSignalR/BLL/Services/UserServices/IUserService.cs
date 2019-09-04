using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DomainModels;
using DAL.Models;

namespace BLL.Services.UserServices
{
    public interface IUserService
    {
        Task<List<UserSession>> GetUserSessions(int userId);
        Task<User> GetUserByToken(string token);
        Task<UserSession> Login(UserLoginModel user);
        Task logOut();
        Task<User> Registration(User user);
        Task UpdateUserSessionDate(string token);
    }
}