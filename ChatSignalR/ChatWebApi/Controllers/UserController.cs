using BLL.DomainModels;
using BLL.Mappers.UserMappers;
using BLL.Services.UserServices;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChatWebApi.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        [Route("Registration")]
        public async Task<ResponseDto<UserDto>> Registration(UserDto user)
        {
            var dbUser = await _userService.Registration(user.MapToUser());

            return new ResponseDto<UserDto>()
            {
                Data = dbUser.MapToUserDto()
            };
        }


        [HttpPost]
        [Route("Login")]
        public async Task<ResponseDto<UserSessionDto>> Login(UserLoginModel user)
        {
            var dbSession = await _userService.Login(user);

            return new ResponseDto<UserSessionDto>()
            {
                Data = dbSession.MapToUserSession()
            };
        }


        [HttpPost]
        [Route("logOut")]
        public async Task logOut()
        {
            await _userService.logOut();
        }
    }
}