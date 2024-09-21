using NextPizza.Core.Models;

namespace NextPizza.Core.Abstractions
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Pizza> CreateProduct(Pizza product);
    }
}
