using System;
using Microsoft.Extensions.Caching.Memory;


namespace RentalPortal.Order.Common.Cache
{
    public class MemoryCacheManager : ICacheManager
    {
        private readonly IMemoryCache _cache;

        public MemoryCacheManager(IMemoryCache cache)
        {
            _cache = cache;
        }


        public void Add(string key, object value, TimeSpan idle = new TimeSpan())
        {
            var cachingPolicy = new  MemoryCacheEntryOptions
            {
                SlidingExpiration = idle == default(TimeSpan) ? TimeSpan.FromHours(12) : idle
            };
            _cache.Set(key,value, cachingPolicy);
        }

        public object Get(string key)
        {
            return _cache.Get(key);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public bool Contains(string key)
        {
            return _cache.TryGetValue(key,out string _);
        }
    }
}
