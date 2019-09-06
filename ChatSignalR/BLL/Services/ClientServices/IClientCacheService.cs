using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Services.ClientServices
{
    public interface IClientCacheService
    {
        Task<List<Error>> GetErrorsAsync();
    }
}