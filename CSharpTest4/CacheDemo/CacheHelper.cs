using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace CacheDemo
{
    public static class CacheHelper
    {
        private static MemoryCache _cache = MemoryCache.Default;

        public static bool AddItem(string key, object value, double seconds)
        {
            DateTimeOffset offset = new DateTimeOffset(DateTime.Now.AddSeconds(seconds));

            return _cache.Add(key, value, offset);
        }

        public static object GetItem(string key)
        {
            return _cache.Get(key);
        }

    }
}
