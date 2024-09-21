using CSharpFunctionalExtensions;
using NextPizza.Core.Models;

namespace NextPizza.Core.Abstractions
{
    public interface IDoughTypeRepository
    {
        Task<Result<DoughType>> GetById(Guid id);
    }
}