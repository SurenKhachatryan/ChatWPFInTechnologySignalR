using BLL.Core;
using BLL.Mappers.ErrorMappers;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;

namespace ChatWebApi.AttributeFilters
{
    public class AppExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.ContentType = "application/json";

            var responce = new ResponseDto<object>()
            {
                HasError = true,
                Errors = new List<ErrorModelDto>()
            };

            if (context.Exception is AppException)
            {
                var exception = context.Exception as AppException;
                responce.Errors = exception.Errors.MapToErrorModelDtos();
            }
            else
            {
                responce.Errors.Add(new ErrorModelDto()
                {
                    Code = -1,
                    Description = "General Error"
                });
            }

            context.Result = new JsonResult(responce);

            base.OnException(context);
        }
    }
}
