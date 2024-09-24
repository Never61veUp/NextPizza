using CSharpFunctionalExtensions;
using NextPizza.Core.Abstractions;
using NextPizza.Core.Models;
using NextPizza.Persistence.Entities;
using NextPizza.Persistence.Repositories;

namespace NextPizza.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public async Task<Result<Product>> CreatePizza(Product product)
        {
            _productsRepository.CreatePizza(product);
            return Result.Success(product);
        }
        
    }

}
