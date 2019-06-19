using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DomainModels;
using DTO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileManagementController : ControllerBase
    {
        [HttpPost]
        public async Task<bool> UploadFile(FileRequest file)
        {

            await Task.CompletedTask;
            return true;
        }

        [HttpPost]
        public async Task<bool> UploadFiles(FilesRequest files)
        {

            await Task.CompletedTask;
            return true;
        }

        public async Task<ResponseDto<bool>> DeleteFiles(BaseFileInfo file)
        {

            await Task.CompletedTask;
            return new ResponseDto<bool>
            {
                Data = true
        };
    }
}
}