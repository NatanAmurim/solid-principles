namespace CacheDemo.Domain.Infra
{
    public interface IProductCache
    {
        public Task<string?> GetProductById(string cacheKey);
        public Task SetProduct(string cacheKey, string product);
    }
}
