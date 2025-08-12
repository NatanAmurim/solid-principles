using CacheDemo.Domain.Infra;
using Microsoft.Extensions.Caching.Memory;

namespace CacheDemo.Infra
{
    public class MemoryProductCache(IMemoryCache memoryCache) : IProductCache
    {
        public async Task<string?> GetProductById(string cacheKey)
        {
            memoryCache.TryGetValue(cacheKey, out string? product);
            return await Task.FromResult(product);
        }

        public Task SetProduct(string cacheKey, string product)
        {
            memoryCache.Set(cacheKey, product, new MemoryCacheEntryOptions 
            { 
                // Se o cache não for utilizado no tempo determinado, ele será apagado e renovado na próxima requisição.
                SlidingExpiration = TimeSpan.FromSeconds(10)
            });
            return Task.CompletedTask;
        }
    }
}
