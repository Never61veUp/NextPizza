using Microsoft.EntityFrameworkCore;
using NextPizza.Core.Abstractions;
using NextPizza.Core.Models;

namespace NextPizza.Persistence.Repositories
{
    public class ProductsRepository : IProductsRepository

    //подумать о продукте
    {
        private readonly NextPizzaDbContext _context;
        public ProductsRepository(NextPizzaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pizza>> Get()
        {
            var pizzasEntities = await _context.Pizzas.AsNoTracking().ToListAsync();

            var pizzas = pizzasEntities
                .Select(p => Pizza.Create(p.Id, p.Ingredients, p.Size, p.DoughType, p.IsVegan).pizza).ToList();
            return pizzas;
        }
        // Create Pizza 16:33



    }
}
