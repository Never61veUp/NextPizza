using CSharpFunctionalExtensions;
using NextPizza.Core.Models;

namespace NextPizza.Core.Abstractions
{
    public interface IDoughTypeRepository
    {
        Task<Result<Guid>> Create(DoughType doughType);
        Task<Result<Guid>> Delete(Guid id);
        Task<Result<IReadOnlyCollection<DoughType>>> GetAllAsync();
        Task<Result<DoughType>> GetById(Guid id);
        Task<Result<Guid>> Update(Guid id, DoughType doughType);
    }
}