using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using NextPizza.Core.Abstractions;
using NextPizza.Core.Models;
using NextPizza.Persistence.Entities;

namespace NextPizza.Persistence.Repositories
{


    public class SizeRepository : ISizeRepository
    {
        private readonly NextPizzaDbContext _context;

        public SizeRepository(NextPizzaDbContext context)
        {
            _context = context;
        }


        public async Task<Result<Guid>> Create(Size size)
        {
            var sizeEntity = new SizeEntity
            {
                Id = size.Id,
                Title = size.Title,
                SizeInCm = size.SizeInCm
            };
            await _context.Sizes.AddAsync(sizeEntity);
            await _context.SaveChangesAsync();

            return sizeEntity.Id;
        }

        public async Task<Result<Guid>> Delete(Guid id)
        {
            await _context.Sizes.Where(x => x.Id == id).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
            return Result.Success(id);
        }

        public async Task<Result<IReadOnlyCollection<Size>>> GetAllAsync()
        {
            var sizeEntities = await _context.Sizes.AsNoTracking().ToListAsync();

            var sizes = sizeEntities
                .Select(b => Size.CreateExisting(b.Id, b.Title, b.SizeInCm).Value).ToList();

            return sizes;


        }

        public async Task<Result<Size>> GetById(Guid id)
        {
            var sizeEntity = await _context.Sizes.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
            var size = Size.CreateExisting(sizeEntity.Id, sizeEntity.Title, sizeEntity.SizeInCm).Value;
            return size;
        }
        public async Task<Result<Guid>> Update(Guid id, Size size)
        {
            await _context.Sizes
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Title, b => size.Title)
                    .SetProperty(b => b.SizeInCm, b => size.SizeInCm));
            await _context.SaveChangesAsync();

            return id;

        }
    }

}
