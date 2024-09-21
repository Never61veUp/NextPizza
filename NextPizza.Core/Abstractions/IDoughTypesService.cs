
using CSharpFunctionalExtensions;
using NextPizza.Core.Models;

namespace NextPizza.Core.Abstractions
{
    public interface IDoughTypesService
    {
        Task<Result<DoughType>> GetDoughType(Guid id);
    }
}