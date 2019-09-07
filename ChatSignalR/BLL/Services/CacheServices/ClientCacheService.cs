using BLL.Constatns;
using BLL.Helpers;
using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services.CacheServices
{
    public class ClientCacheService : IClientCacheService
    {
        private readonly HttpHelpers _httpHelpers;

        public ClientCacheService(HttpHelpers httpHelpers)
        {
            _httpHelpers = httpHelpers;
        }


        public async Task<List<Error>> GetErrorsAsync()
        {
            return await _httpHelpers.GetAsync<List<Error>>(CacheConstants.Controllers.Error +
                                                            CacheConstants.Actions.GetErrors);
        }
    }
}
