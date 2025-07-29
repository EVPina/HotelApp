using HotelWebApi.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace HotelWebApi.Services
{
    public class SCaching : ICaching
    {
        private readonly IMemoryCache _cache;

        public SCaching(IMemoryCache cache)
        {
            _cache = cache;
        }

        public T GetorSet<T>(string key,Func<T> getData,int time)
        {
            if (_cache.TryGetValue(key, out T cachevalue))
            {
                return cachevalue;
            }
            T data = getData();

            _cache.Set(key, data, TimeSpan.FromMinutes(time));

            return data;
        }
     
        public async Task<T> GetOrSetAsync<T>(string key,Func<Task<T>> getData,int time)
        {
            if (_cache.TryGetValue(key, out T cachevalue))
            {
                return cachevalue;
            }
            T data = await getData();

            _cache.Set(key, data, TimeSpan.FromMinutes(time));

            return data;
        }
        public void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}
