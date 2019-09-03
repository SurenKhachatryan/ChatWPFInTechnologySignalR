using BLL.Constatns;
using BLL.Core;
using BLL.DomainModels;
using BLL.Extensions;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly ChatDBContext _db;
        private readonly UserIdentity _userIdentity;

        public UserService(ChatDBContext db, UserIdentity userIdentity)
        {
            _db = db;
            _userIdentity = userIdentity;
        }


        public async Task<User> Registration(User user)
        {
            if (_db.User.Any(x => x.LoginName == user.LoginName))
            {
                throw new AppException(ErrorConstants.UserAlreadyExists);
            }

            if (_db.User.Any(x => x.Email == user.Email))
            {
                throw new AppException(ErrorConstants.UserWithThatEmailAlreadyExists);
            }

            //TODO AppSettings

            var HashPassword = PasswordExtension.CreatePasswordHash(user.Password, "Hello World");

            var date = DateTime.UtcNow;

            var newUser = _db.User.Add(new User
            {
                BirthDate = user.BirthDate,
                CreationDate = date,
                LastUpdateDate = date,
                Email = user.Email,
                FirstName = user.FirstName,
                IsBlocked = false,
                IsDeleted = false,
                IsEmailVerified = false,
                LoginName = user.LoginName,
                LastName = user.LastName,
                Password = HashPassword
            });

            await _db.SaveChangesAsync();

            return newUser.Entity;
        }


        public async Task<UserSession> Login(UserLoginModel user)
        {
            var dbUser = await _db.User.FirstOrDefaultAsync(x => x.LoginName == user.LoginNameOrEmail ||
                                                                 x.Email == user.LoginNameOrEmail);
            //TODO AppSettings

            var hashPassword = PasswordExtension.CreatePasswordHash(user.Password, "Hello World");

            if (dbUser == null || hashPassword != dbUser.Password)
            {
                throw new AppException(ErrorConstants.IncorrectPasswordOrUsername);
            }

            if (dbUser.IsBlocked.HasValue && dbUser.IsBlocked.Value)
            {
                throw new AppException(ErrorConstants.UserIsBlocked);
            }

            if (dbUser.IsDeleted.HasValue && dbUser.IsDeleted.Value)
            {
                throw new AppException(ErrorConstants.UserIsDeleted);
            }

            if (dbUser.IsEmailVerified.HasValue && !dbUser.IsEmailVerified.Value)
            {
                throw new AppException(ErrorConstants.UserWithThatEmailAlreadyExists);
            }

            var date = DateTime.UtcNow;

            var token = Guid.NewGuid().ToString();

            var newSession = _db.UserSession.Add(new UserSession
            {
                CreationDate = date,
                ModificationDate = date,
                Token = token,
                UserId = dbUser.Id,
                User = dbUser
            });

            await _db.SaveChangesAsync();

            return newSession.Entity;
        }


        public async Task logOut()
        {
            var dbUserSession = await _db.UserSession.FirstOrDefaultAsync(x => x.Token == _userIdentity.Token);

            if (dbUserSession != null)
            {
                _db.UserSession.Remove(dbUserSession);

                await _db.SaveChangesAsync();
            }
        }


        public async Task<List<UserSession>> GetUserSessions(int userId)
        {
            var userSessions = await _db.UserSession.Where(x => x.UserId == userId).ToListAsync();

            return userSessions;
        }


        public async Task UpdateUserSessionDate(string token)
        {
            var dbUserSession = await _db.UserSession.FirstOrDefaultAsync(x => x.Token == token);

            var date = DateTime.UtcNow;

            if (dbUserSession != null)
            {
                dbUserSession.ModificationDate = date;

                await _db.SaveChangesAsync();
            }
        }
    }
}
