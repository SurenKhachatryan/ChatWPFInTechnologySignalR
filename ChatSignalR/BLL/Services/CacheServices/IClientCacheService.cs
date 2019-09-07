using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Services.CacheServices
{
    public interface IClientCacheService
    {
        Task<List<Error>> GetErrorsAsync();
    }
}