using CSharpFunctionalExtensions;
using NextPizza.Core.Abstractions;
using NextPizza.Core.Models;

namespace NextPizza.Application.Services
{
    internal class DoughTypesService : IDoughTypesService
    {
        private readonly IDoughTypeRepository _doughTypesRepository;

        public DoughTypesService(IDoughTypeRepository doughTypeRepository)
        {
            _doughTypesRepository = doughTypeRepository;
        }

        public async Task<Result<IReadOnlyCollection<DoughType>>> GetAllAsync(Guid id)
        {
            var getAllResult = await _doughTypesRepository.GetAllAsync();
            if (getAllResult.IsFailure)
            {
                return Result.Failure<IReadOnlyCollection<DoughType>>(getAllResult.Error);
            }

            return Result.Success(getAllResult.Value);
        }
        public async Task<Result<Guid>> CreateAsync(DoughType doughType)
        {
            var createResult = await _doughTypesRepository.Create(doughType);
            if (createResult.IsFailure)
            {
                return Result.Failure<Guid>(createResult.Error);
            }

            return Result.Success(createResult.Value);
        }
        public async Task<Result<DoughType>> GetByIdAsync(Guid id)
        {
            var getByIdResult = await _doughTypesRepository.GetById(id);
            if (getByIdResult.IsFailure)
            {
                return Result.Failure<DoughType>(getByIdResult.Error);
            }

            return Result.Success(getByIdResult.Value);
        }
        public async Task<Result<DoughType>> UpdateAsync(Guid id, DoughType doughType)
        {
            var updateResult = await _doughTypesRepository.Update(id, doughType);
            if (updateResult.IsFailure)
            {
                return Result.Failure<DoughType>(updateResult.Error);
            }

            return Result.Success(updateResult.Value);
        }
        public async Task<Result<Guid>> DeleteAsync(Guid id)
        {
            var updateResult = await _doughTypesRepository.Delete(id);
            if (updateResult.IsFailure)
            {
                return Result.Failure<Guid>(updateResult.Error);
            }

            return Result.Success(updateResult.Value);
        }

    }
}
