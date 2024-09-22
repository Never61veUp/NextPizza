using CSharpFunctionalExtensions;
using NextPizza.Core.Models;

namespace NextPizza.Core.Abstractions
{
    public interface IProductService
    {
        Task<Result<Pizza>> CreatePizza(Pizza product);
    }
}
