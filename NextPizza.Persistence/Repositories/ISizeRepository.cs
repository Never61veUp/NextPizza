using NextPizza.Core.Models;

namespace NextPizza.Persistence.Repositories
{
    public interface ISizeRepository
    {
        Task<IEnumerable<Size>> GetAll();
        Task<Guid> Create(Size size);
        Task<Size> GetById(Guid id);
    }
}