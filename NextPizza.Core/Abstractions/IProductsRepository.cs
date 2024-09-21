using NextPizza.Core.Models;

namespace NextPizza.Core.Abstractions
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Pizza>> Get();
        Task<Guid> Create(Pizza pizza);
    }
}
