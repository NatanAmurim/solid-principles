using CacheDemo.Domain.Infra;
using Microsoft.Extensions.Caching.Distributed;

namespace CacheDemo.Infra
{
    public class RedisProductCache(IDistributedCache distributedCache) : IProductCache
    {
        public async Task<string?> GetProductById(string cacheKey)
        {
            try
            {
                return await distributedCache.GetStringAsync(cacheKey);
            }
            catch (Exception)
            {

                return string.Empty;
            }
            
        }

        public async Task SetProduct(string cacheKey, string product)
        {
            try
            {
                await distributedCache.SetStringAsync(cacheKey, product);
            }
            catch (Exception)
            {
                return;                
            }            
        }
    }
}
