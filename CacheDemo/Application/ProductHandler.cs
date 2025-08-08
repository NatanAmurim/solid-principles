using CacheDemo.Application;

namespace CacheDemo.Services
{
    public class ProductHandler(ProductCacheHandler productCacheHandler)
    {
        public async Task<string> GetProductByIdAsync(string id)
        {
            var product = string.Empty;

            product = await productCacheHandler.GetProductById(id);

            if (string.IsNullOrEmpty(product))
            {                
                await Task.Delay(5000); // simulção de lentidão
                product = $"Produto {id} - Arroz";
                
                await productCacheHandler.SetProduct(id, product);

                return product;
            }

            return product;
        }
    }
}
