using CacheDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CacheDemo.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductHandler _productService;    
        public ProductController(ProductHandler productService) 
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string id)
        {
            var result = await _productService.GetProductByIdAsync(id);
            
            return Ok(result);
        }
    }
}
