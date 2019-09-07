using DAL.Models;
using System.Collections.Concurrent;

namespace BLL.Services.CacheServices
{
    public static class Cache
    {
        public static ConcurrentDictionary<int, Error> Errors { get; set; }
    }
}
