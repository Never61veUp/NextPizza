using Microsoft.AspNetCore.Mvc;
using NextPizza.API.Contracts;
using NextPizza.Core.Abstractions;
using NextPizza.Core.Models;
using NextPizza.Core.Stores;

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

        //[HttpGet]
        //public async Task<ActionResult<List<ProductResponse>>> GetProducts()
        //{
        //    var products = await _productService.GetAllProducts();

        //    var response = products.Select(p => new ProductResponse(
        //        p.Id,
        //        p.Name,
        //        p.Price
        //        ));
        //    return Ok(response);
        //}

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] ProductRequest request)
        {
            var size = Size.FindById()


            var pizza = Pizza.Create(Guid.NewGuid(), request.Title, request.Price, request.IsNewProduct, request.ImageUrl, request.Ingredients , 1, 1, true);
            _productService.CreateProduct(pizza);
            return Ok();
        }
    }
}
