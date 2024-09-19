using Microsoft.AspNetCore.Mvc;
using NextPizza.API.Contracts;
using NextPizza.Core.Abstractions;

namespace NextPizza.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductResponse>>> GetProducts()
        {
            var products = await _productService.GetAllProducts();

            var response = products.Select(p => new ProductResponse(
                p.Id,
                p.Name,
                p.Price
                ));
            return Ok(response);
        }
    }
}
