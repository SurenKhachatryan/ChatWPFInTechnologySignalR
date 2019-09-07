using System.Collections.Concurrent;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Services.CacheServices
{
    public interface ICacheService
    {
        Task<ConcurrentDictionary<int, Error>> GetErrors();
    }
}