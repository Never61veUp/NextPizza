using NextPizza.Core.Abstractions;
using NextPizza.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPizza.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productsRepository.Get();
        }
        public async Task<Guid> CreateProduct(Pizza product)
        {
            return await _productsRepository.Create(product);
        }

        public async Task<Pizza> FinById()
        {
            return await _productsRepository.Get();
        }
        //Create
    }
}
