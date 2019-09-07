using BLL.Constatns;
using BLL.Helpers;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Core
{
    public class AppException : Exception
    {
        private readonly string _cachUrl = AppConfigSettings.CacheUrl;
        private readonly static HttpHelpers _httpHelpers;

        private List<ErrorModel> errors = new List<ErrorModel>();

        public List<ErrorModel> Errors { get { return errors; } }



        static AppException()
        {
            _httpHelpers = Services.HttpHelpers;
        }

        public AppException()
        {
        }

        public AppException(int code)
        {
            CreatError(code);
        }


        public AppException(List<int> codes)
        {
            CreateError(codes);
        }


        public AppException(int code, string description)
        {
            CreateError(code, description);
        }


        public AppException(List<ErrorModel> errors)
        {
            CreateError(errors);
        }


        private void CreatError(int code)
        {
            var error = _httpHelpers.GetAsync<Error>(_cachUrl + CacheConstants.Controllers.Error + CacheConstants.Actions.GetErrorById + code).Result;

            errors.Add(new ErrorModel()
            {
                Code = code,
                Description = error.Translation
            });
        }


        private void CreateError(List<int> codes)
        {
            var dbErrors = _httpHelpers.GetAsync<List<Error>>(_cachUrl + CacheConstants.Controllers.Error + CacheConstants.Actions.GetErrors).Result;

            foreach (var code in codes)
            {
                errors.Add(new ErrorModel()
                {
                    Code = code,
                    Description = dbErrors.FirstOrDefault(x => x.Id == code)?.Translation
                });
            }
        }


        private void CreateError(int code, string description)
        {
            errors.Add(new ErrorModel()
            {
                Code = code,
                Description = description
            });
        }


        private void CreateError(List<ErrorModel> errors)
        {
            errors.AddRange(errors);
        }
    }
}
