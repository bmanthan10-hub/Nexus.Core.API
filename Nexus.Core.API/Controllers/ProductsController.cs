using Microsoft.AspNetCore.Mvc;
using Nexus.Core.API.Services;
using SerilogTimings;

namespace Nexus.Core.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Request started: GET /api/products");

            using var op = Operation.Time("Fetching all products");
            var products = await _productService.GetAllProductsAsync();

            _logger.LogInformation("Data successfully returned: all products");
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation("Request started: GET /api/products/{Id}", id);

            using var op = Operation.Time("Fetching product {Id}", id);
            var product = await _productService.GetProductByIdAsync(id);

            _logger.LogInformation("Data successfully returned: product {Id}", id);
            return Ok(product);
        }
    }
}