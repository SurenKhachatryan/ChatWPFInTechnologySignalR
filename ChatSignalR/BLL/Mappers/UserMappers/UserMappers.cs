using DAL.Models;
using DTO.Models;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Mappers.UserMappers
{
    public static class UserMappers
    {
        public static User MapToUser(this UserDto model)
        {
            if (model == null)
                return null;

            return new User()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                LoginName = model.LoginName,
                Email = model.Email,
                Password = model.Password,
                LastUpdateDate = model.LastUpdateDate,
                CreationDate = model.CreationDate,
                BirthDate = model.BirthDate,
            };
        }

        public static UserDto MapToUserDto(this User model)
        {
            if (model == null)
                return null;

            return new UserDto()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                LoginName = model.LoginName,
                Email = model.Email,
                LastUpdateDate = model.LastUpdateDate,
                CreationDate = model.CreationDate,
                BirthDate = model.BirthDate,
            };
        }


        public static List<User> MapToUsers(this List<UserDto> models)
        {
            if (models != null)
                return models.Select(MapToUser).ToList();

            return new List<User>();
        }


        public static List<UserDto> MapToUserDto(this List<User> models)
        {
            if (models != null)
                return models.Select(MapToUserDto).ToList();

            return new List<UserDto>();
        }


        public static UserSessionDto MapToUserSession(this UserSession model)
        {
            if (model == null)
                return null;

            return new UserSessionDto()
            {
                UserId = model.UserId ?? 0,
                Token = model.Token,
                Email = model.User.Email,
                LoginName = model.User.LoginName,
                LastName = model.User.LastName,
                FirstName = model.User.FirstName
            };
        }
    }
}
