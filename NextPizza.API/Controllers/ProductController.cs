using Microsoft.AspNetCore.Mvc;
using NextPizza.Core.Abstractions;


namespace NextPizza.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ISizesService _sizeService;
        private readonly IDoughTypesService _doughTypesService;

        public ProductsController(IProductService productService, ISizesService sizeService, IDoughTypesService doughTypesService)
        {
            _productService = productService;
            _sizeService = sizeService;
            _doughTypesService = doughTypesService;
        }


    }
}
