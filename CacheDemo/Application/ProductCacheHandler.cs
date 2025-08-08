using CacheDemo.Domain.Infra;

namespace CacheDemo.Application
{
    public class ProductCacheHandler([FromKeyedServices(Constants.PRODUCT_MEMORY_CHACHE)] IProductCache productMemoryCache, [FromKeyedServices(Constants.PRODUCT_DISTRIBUITED_CACHE)] IProductCache distribuitedProductCache)
    {
        public async Task<string> GetProductById(string id)
        {

            var product = string.Empty;
            product = await productMemoryCache.GetProductById(id);

            if (string.IsNullOrEmpty(product))
                product = await distribuitedProductCache.GetProductById(id);

            return product;
        }

        public async Task SetProduct(string cacheKey, string product)
        {

            await productMemoryCache.SetProduct(cacheKey, product);
            await distribuitedProductCache.SetProduct(cacheKey, product);
        }
    }
}
