using BLL.Constatns;
using BLL.Core;
using BLL.Services.UserServices;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace ChatWebApi.AttributeFilters
{
    public class UserAuthorization : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"].ToString();

            if (string.IsNullOrEmpty(token))
            {
                throw new AppException(ErrorConstants.UnAuthorized);
            }

            var userService = context.HttpContext.RequestServices.GetService(typeof(IUserService)) as IUserService;

            var user = userService.GetUserByToken(token).Result;

            if (user == null)
            {
                throw new AppException(ErrorConstants.UnAuthorized);
            }

            if (user.IsBlocked.HasValue && user.IsBlocked.Value)
            {
                throw new AppException(ErrorConstants.UserIsBlocked);
            }

            if (user.IsDeleted.HasValue && user.IsDeleted.Value)
            {
                throw new AppException(ErrorConstants.UserIsDeleted);
            }

            if (user.IsEmailVerified.HasValue && !user.IsEmailVerified.Value)
            {
                throw new AppException(ErrorConstants.UserWithThatEmailAlreadyExists);
            }

            //TODO AppSettings Get Expired Time from DB

            var userSession = user.UserSession.FirstOrDefault(x => x.Token == token);

            var time = userSession.ModificationDate.AddMinutes(150);

            if (time > DateTime.UtcNow)
            {
                throw new AppException(ErrorConstants.SessionExpired);
            }

            userService.UpdateUserSessionDate(token);

            var userIdentity = context.HttpContext.RequestServices.GetService(typeof(UserIdentity)) as UserIdentity;

            userIdentity.Id = user.Id;
            userIdentity.Token = token;
            userIdentity.UserName = user.LoginName;
            userIdentity.Email = user.Email;
        }
    }
}
