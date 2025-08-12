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
                await distributedCache.SetStringAsync(cacheKey, product, new DistributedCacheEntryOptions
                {
                    //Após o tempo de expiração a partir da primeira requisição
                    //O cache será apagado.
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10)
                });
            }
            catch (Exception)
            {
                return;                
            }            
        }
    }
}
