using NextPizza.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPizza.Persistence.Repositories
{
    internal class SizeRepository : ISizeRepository
    {
        private readonly NextPizzaDbContext _context;
        public SizeRepository(NextPizzaDbContext context)
        {
            _context = context;
        }
        public Task<Guid> Create(Size size)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Size>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Size> GetById(Guid id)
        {
            var sizeEntities = _context.Sizes.Where(x => x.Id == id).FirstOrDefault();

            var sizes = Size.Create(sizeEntities.Id, sizeEntities.Title, sizeEntities.SizeInCm).Value;

            return sizes;
        }
    }
}
