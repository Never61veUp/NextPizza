
using CSharpFunctionalExtensions;
using NextPizza.Core.Models;

namespace NextPizza.Core.Abstractions
{
    public interface IDoughTypesService
    {
        Task<Result<Guid>> CreateAsync(DoughType doughType);
        Task<Result<Guid>> DeleteAsync(Guid id);
        Task<Result<IReadOnlyCollection<DoughType>>> GetAllAsync();
        Task<Result<DoughType>> GetByIdAsync(Guid id);
        Task<Result<DoughType>> UpdateAsync(Guid id, DoughType doughType);
    }
}