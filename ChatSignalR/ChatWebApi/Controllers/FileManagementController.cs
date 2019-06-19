using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DomainModels;
using BLL.Services.FileManagmentServices;
using DTO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatWebApi.Controllers
{
    [Route("api/FileManagement")]
    [ApiController]
    public class FileManagementController : ControllerBase
    {
        public IFileManagmentServices _fileManagmentServices;
        public IFileServices _fileServices;

        public FileManagementController(IFileManagmentServices fileManagmentServices, IFileServices fileServices)
        {
            _fileManagmentServices = fileManagmentServices;
            _fileServices = fileServices;
        }

        [HttpPost]
        [Route("UploadFile")]
        public async Task<ResponseDto<bool>> UploadFile(FileRequest file)
        {

            await Task.CompletedTask;
            return new ResponseDto<bool>()
            {
                Data = true
            };
        }

        [HttpPost]
        [Route("UploadFiles")]
        public async Task<ResponseDto<bool>> UploadFiles(FilesRequest files)
        {

            await Task.CompletedTask;
            return new ResponseDto<bool>()
            {
                Data = true
            };
        }

        [HttpPost]
        [Route("DeleteFiles")]
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