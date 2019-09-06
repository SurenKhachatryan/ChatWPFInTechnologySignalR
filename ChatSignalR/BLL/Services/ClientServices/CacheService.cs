using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace BLL.Services.ClientServices
{
    public class CacheService : ICacheService
    {
        private readonly ChatDBContext _db;

        public CacheService(ChatDBContext db)
        {
            _db = db;
            InitializeCacheProperties().Wait();
        }

        public async Task<ConcurrentDictionary<int, Error>> GetErrors()
        {
            return new ConcurrentDictionary<int, Error>(await _db.Error.ToDictionaryAsync(x => x.Id, x => x));
        }


        private async Task InitializeCacheProperties()
        {
            var getErrors = GetErrors();

            Task.WaitAll(getErrors);

            Cache.Errors = await getErrors;
        }
    }
}
