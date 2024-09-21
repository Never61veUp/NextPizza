using CSharpFunctionalExtensions;
using NextPizza.Core.Models;

namespace NextPizza.Core.Abstractions
{
    public interface ISizesService
    {
        Task<Result<Size>> CreateAsync(Size size);
        Task<Result<Size>> GetByIdAsync(Guid id);
        Task<Result<IReadOnlyCollection<Size>>> GetAllAsync();
        Task<Result<Size>> UpdateAsync(Guid id, Size size);
        Task<Result<Guid>> DeleteAsync(Guid id);

    }
}