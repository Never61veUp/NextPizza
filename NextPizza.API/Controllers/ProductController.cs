using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using NextPizza.API.Contracts;
using NextPizza.Application.Services;
using NextPizza.Core.Abstractions;
using NextPizza.Core.Models;
using NextPizza.Persistence.Entities;


namespace NextPizza.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ISizesService _sizesService;
        private readonly IDoughTypesService _doughTypesService;

        public ProductController(IProductService productService, ISizesService sizesService, IDoughTypesService doughTypesService)
        {
            _productService = productService;
            _sizesService = sizesService;
            _doughTypesService = doughTypesService;
        }

        [HttpPost("{type}")]
        public async Task<IActionResult> CreatePizza([FromBody] ProductRequest request, string type)
        {

            List<string> myList = new List<string> { "1", "2", "3", "4", "5" };
            IReadOnlyList<string> readOnlyList = myList;

            

            Product product;
            if (type == "pizza")
            {
                var size = await _sizesService.GetByIdAsync(request.SizeId);
                var doughType = await _doughTypesService.GetByIdAsync(request.DoughTypeId);
                product = Pizza.CreateNew(request.Title, request.Price, request.IsNewProduct, "", 
                    readOnlyList, size.Value, doughType.Value, request.IsVegan).Value;

                
            }
            else
            {
                product = Drink.CreateNew(request.Title, request.Price, request.IsNewProduct, "", 
                    request.IsAlcoholic, request.VolumeInLiters).Value;
            }
            await _productService.CreatePizza(product);


            return Ok();
        }
    }


}
