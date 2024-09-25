using CSharpFunctionalExtensions;
using NextPizza.Core.Models;

namespace NextPizza.Core.Abstractions
{
    public interface IProductService
    {
        Task<Result<Product>> CreatePizza(Product product);
        Task<Result<IEnumerable<Product>>> GetAllProducts();
    }
}
