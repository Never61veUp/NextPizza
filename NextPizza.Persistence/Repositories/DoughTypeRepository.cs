using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using NextPizza.Core.Abstractions;
using NextPizza.Core.Models;
using NextPizza.Persistence;
using NextPizza.Persistence.Entities;

public class DoughTypeRepository : IDoughTypeRepository
{
    private readonly NextPizzaDbContext _context;

    public DoughTypeRepository(NextPizzaDbContext context)
    {
        _context = context;
    }

    public async Task<Result<Guid>> Create(DoughType doughType)
    {
        var doughTypeEntity = new DoughTypeEntity
        {
            Id = doughType.Id,
            Title = doughType.Title,
            ThicknessInCm = doughType.ThicknessInCm
        };

        await _context.DoughTypes.AddAsync(doughTypeEntity);
        await _context.SaveChangesAsync();

        return Result.Success(doughTypeEntity.Id);
    }
    public async Task<Result<Guid>> Delete(Guid id)
    {
        var doughTypeEntity = await FindByIdAsync(id);
        if (doughTypeEntity == null)
            return Result.Failure<Guid>("Dough type not found");

        _context.DoughTypes.Remove(doughTypeEntity);
        await _context.SaveChangesAsync();

        return Result.Success(id);
    }
    public async Task<Result<IReadOnlyCollection<DoughType>>> GetAllAsync()
    {
        var doughTypeEntities = await _context.DoughTypes.AsNoTracking().ToListAsync();
        IReadOnlyCollection<DoughType> doughTypes = doughTypeEntities
            .Select(MapToDoughType)
            .ToList();

        return Result.Success(doughTypes);
    }
    public async Task<Result<DoughType>> GetById(Guid id)
    {
        var doughTypeEntity = await FindByIdAsync(id);
        if (doughTypeEntity == null)
            return Result.Failure<DoughType>("Dough type not found");

        return Result.Success(MapToDoughType(doughTypeEntity)).Value;
    }
    public async Task<Result<DoughType>> Update(Guid id, DoughType doughType)
    {
        var existingDoughType = await _context.DoughTypes.FindAsync(id);
        if (existingDoughType == null)
            return Result.Failure<DoughType>("Dough type not found");

        existingDoughType.Title = doughType.Title;
        existingDoughType.ThicknessInCm = doughType.ThicknessInCm;

        await _context.SaveChangesAsync();

        return Result.Success(doughType);
    }

    private DoughType MapToDoughType(DoughTypeEntity entity)
    {
        var result = DoughType.CreateExisting(entity.Id, entity.Title, entity.ThicknessInCm);

        if (result.IsFailure)
            throw new InvalidOperationException("Error creating dough type from entity.");

        return result.Value;
    }
    private async Task<DoughTypeEntity> FindByIdAsync(Guid id)
    {
        return await _context.DoughTypes.FindAsync(id);
    }
}
