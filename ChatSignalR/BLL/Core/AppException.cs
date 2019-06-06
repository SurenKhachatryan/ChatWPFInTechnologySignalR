using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Core
{
    class AppException
    {
        private readonly string _cachUrl = AppConfigSettings.CacheUrl;
        public List<ErrorModel> Errors { get; private set; } = new List<ErrorModel>();


        #region ctor

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


        #endregion

        #region Private Methods

        private void CreatErrorAsync(int code)
        {

            //var error = Get<Error>(_cachUrl + CachConstants.Controllers.Error + CachConstants.Actions.GetErrorByIdAsync + code);

            Errors.Add(new ErrorModel()
            {
                //Code = code,
                //Description = error.Translation
            });
        }

        private void CreatError(List<int> codes)
        {
            //var errors = Get<List<Error>>(_cachUrl + CachConstants.Controllers.Error + CachConstants.Actions.GetErrorsAsync);

            foreach (var code in codes)
            {
                Errors.Add(new ErrorModel()
                {
                    //Code = code,
                    //Description = errors.FirstOrDefault(x => x.Id == code)?.Translation
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


        //private T Get<T>(string url)
        //{
        //    //using (var client = new HttpClient())
        //    //{
        //    //    var responce = client.GetStringAsync(url).Result;

        //    //    return JsonConvert.DeserializeObject<T>(responce);
        //    //}

        //}
        #endregion
    }
}
