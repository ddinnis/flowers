using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowers_web.Common
{
    public class MemoryHelper
    {
        private static IMemoryCache _memoryCache;
        static MemoryHelper()
        {
            if (_memoryCache == null)
            {
                _memoryCache = new MemoryCache(new MemoryCacheOptions());

            }
        }

        ///在生成验证码时存入key，value(验证码)和有效期
        public static void SetMemory(string key, object value, int expireMins)
        {
            if (_memoryCache == null)
            {
                _memoryCache = new MemoryCache(new MemoryCacheOptions());

            }
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(expireMins));
        }

        ///用key来获取缓存的验证码
        public static object GetMemory(string key)
        {
            return _memoryCache.Get(key);
        }
    }
}
