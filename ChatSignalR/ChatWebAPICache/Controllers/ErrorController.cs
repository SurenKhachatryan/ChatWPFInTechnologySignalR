using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services.ClientServices;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatWebAPICache.Controllers
{
    [Route("api/Error")]
    [ApiController]
    public class ErrorController : ControllerBase
    {

        [HttpGet]
        [Route("GetErrors")]
        public async Task<List<Error>> GetErrorsAsync()
        {
            await Task.CompletedTask;

            return Cache.Errors.Select(x => x.Value).ToList();
        }

        [HttpGet]
        [Route("GetErrorById")]
        public async Task<Error> GetErrorByIdAsync(int id)
        {
            await Task.CompletedTask;

            return Cache.Errors.FirstOrDefault(x => x.Key == id).Value;
        }
    }
}