using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeAPI.Data;
using PracticeAPI.Models.Api;
using PracticeAPI.Models.Entities;
using PracticeAPI.Services;

namespace PracticeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ProductService _productService;

        public ProductController(ApplicationDBContext dBContext, ProductService productService) {
            _dbContext = dBContext;
            _productService = productService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Product>>> GetProducts(int id)
        {
            var products = await _dbContext.Products
                                           .Where(p => p.UserId == id)
                                           .ToListAsync();

            if (products == null || products.Count == 0)
            {
                return NotFound($"No products found for user ID {id}");
            }

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductRequestModel model)
        {
           var result = await _productService.AddProductAsync(model);

            return Ok(result);
        }

    }
}
