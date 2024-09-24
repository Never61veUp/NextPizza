using CSharpFunctionalExtensions;
using NextPizza.Core.Models;

namespace NextPizza.Core.Abstractions
{
    public interface IProductsRepository
    {
        Task<Result<Product>> CreatePizza(Product product);
    }
}
