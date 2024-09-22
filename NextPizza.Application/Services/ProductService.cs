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
        public async Task<Result<Pizza>> CreatePizza(Pizza pizza)
        {
            _productsRepository.CreatePizza(pizza);
            return Result.Success(pizza);
        }
    }

}
