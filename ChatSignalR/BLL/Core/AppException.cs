using BLL.Constatns;
using DAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace BLL.Core
{
    public class AppException : Exception
    {
        private readonly string _cachUrl = AppConfigSettings.CacheUrl;
        public List<ErrorModel> Errors { get; private set; } = new List<ErrorModel>();

        //TODO HttpHelper
       
        public AppException(int code)
        {
            CreatErrorAsync(code);
        }

        public AppException(List<int> codes)
        {
            CreatError(codes);
        }

        public AppException(int code, string description)
        {
            CreatError(code, description);
        }

        public AppException(List<ErrorModel> errors)
        {
            CreatError(errors);
        }

        public AppException()
        {

        }
        

        private void CreatErrorAsync(int code)
        {

            var error = Get<Error>(_cachUrl + CacheConstants.Controllers.Error + CacheConstants.Actions.GetErrorById + code);

            Errors.Add(new ErrorModel()
            {
                Code = code,
                Description = error.Translation
            });
        }


        private void CreatError(List<int> codes)
        {
            var errors = Get<List<Error>>(_cachUrl + CacheConstants.Controllers.Error + CacheConstants.Actions.GetErrors);

            foreach (var code in codes)
            {
                Errors.Add(new ErrorModel()
                {
                    Code = code,
                    Description = errors.FirstOrDefault(x => x.Id == code)?.Translation
                });
            }
        }


        private void CreatError(int code, string description)
        {
            Errors.Add(new ErrorModel()
            {
                Code = code,
                Description = description
            });
        }


        private void CreatError(List<ErrorModel> errors)
        {
            Errors.AddRange(errors);
        }


        private TR Get<TR>(string url)
        {
            using (var client = new HttpClient())
            {
                var responce = client.GetStringAsync(url).Result;

                return JsonConvert.DeserializeObject<TR>(responce);
            }
        }
    }
}
