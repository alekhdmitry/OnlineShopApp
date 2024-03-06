using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopApp.Models;
using OnlineShopApp.Services.ProductService;
using Serilog;

namespace OnlineShopApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService) 
        {
            _productService = productService;
        }

        //[HttpGet(Name = "GetAllProducts")]
        //public async Task<ActionResult<List<Product>>> GetAllProducts()
        //{
        //    return await _productService.GetAllProducts();
        //}

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<ActionResult<Product>> GetSingleProduct(int id)
        {
            var result = await _productService.GetSingleProduct(id);

            if (result is null)
                return NotFound("Product doesn't exist");

            return Ok(result);
        }

        [HttpPost(Name = "AddProduct")]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            var result = await _productService.AddProduct(product);

            return Ok(result);
        }

        [HttpPut(Name = "UpdateProduct")]
        public async Task<ActionResult<List<Product>>> UpdateProduct(int id, Product request)
        {
            var result = await _productService.UpdateProduct(id, request);

            if (result is null)
                return NotFound("Product doesn't exist");

            return Ok(result);
        }

        [HttpDelete("{id}", Name = "DeleteProduct")]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProduct(id);

            if (result is null)
                return NotFound("Product doesn't exist");

            return Ok(result);
        }
    }
}
