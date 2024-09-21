using CSharpFunctionalExtensions;
using NextPizza.Core.Models;

namespace NextPizza.Core.Abstractions
{
    public interface ISizeRepository
    {
        Task<Result<Guid>> Create(Size size);
        Task<Result<Guid>> Delete(Guid id);
        Task<Result<Size>> GetById(Guid id);
        Task<Result<Guid>> Update(Guid id, Size size);
        Task<Result<IReadOnlyCollection<Size>>> GetAllAsync();
    }
}