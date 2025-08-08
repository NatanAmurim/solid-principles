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
            memoryCache.Set(cacheKey, product);
            return Task.CompletedTask;
        }
    }
}
