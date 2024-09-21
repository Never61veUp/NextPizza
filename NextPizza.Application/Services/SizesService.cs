using CSharpFunctionalExtensions;
using NextPizza.Core.Abstractions;
using NextPizza.Core.Models;

namespace NextPizza.Application.Services
{

    public class SizesService : ISizesService
    {
        private readonly ISizeRepository _sizeRepository;

        public SizesService(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        public async Task<Result<Size>> CreateAsync(Size size)
        {
            var CreateResult = await _sizeRepository.Create(size);
            if (CreateResult.IsFailure)
            {
                return Result.Failure<Size>(CreateResult.Error);
            }

            return Result.Success(size);
        }
        public async Task<Result<Guid>> DeleteAsync(Guid id)
        {
            var DeleteResult = await _sizeRepository.Delete(id);
            if (DeleteResult.IsFailure)
            {
                return Result.Failure<Guid>(DeleteResult.Error);
            }

            return Result.Success(id);
        }
        public async Task<Result<IReadOnlyCollection<Size>>> GetAllAsync()
        {
            var GetAllResult = await _sizeRepository.GetAllAsync();

            if (GetAllResult.IsFailure)
            {
                return Result.Failure<IReadOnlyCollection<Size>>(GetAllResult.Error);
            }

            return Result.Success(GetAllResult.Value);
        }
        public async Task<Result<Size>> GetByIdAsync(Guid id)
        {
            var GetById = await _sizeRepository.GetById(id);

            if (GetById.IsFailure)
            {
                return Result.Failure<Size>(GetById.Error);
            }

            return Result.Success(GetById.Value);
        }
        public async Task<Result<Size>> UpdateAsync(Guid id, Size size)
        {
            var UpdateResult = await _sizeRepository.Update(id, size);

            if (UpdateResult.IsFailure)
            {
                return Result.Failure<Size>(UpdateResult.Error);
            }

            return Result.Success(size);
        }
    }
}
