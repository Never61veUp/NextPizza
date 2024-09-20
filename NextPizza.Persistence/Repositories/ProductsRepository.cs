using Microsoft.EntityFrameworkCore;
using NextPizza.Core.Abstractions;
using NextPizza.Core.Models;
using NextPizza.Persistence.Entities;

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
                .Select(p => Pizza.Create(p.Id, p.Title, p.Price, p.IsNewProduct, "", "", p.DoughType, p.IsVegan).pizza).ToList();
            return null;
        }



        // Create Pizza 16:33

        public async Task<Guid> Create(Pizza pizza)
        {
            var pizzaEntity = new PizzaEntity
            {
                Id = pizza.Id,
                Title = pizza.Title,
                Price = pizza.Price,
                IsNewProduct = pizza.IsNewProduct,
                IsVegan = pizza.IsVegan,
                SizeId = pizza.Size.Id,
                DoughTypeId = pizza.DoughType.Id




            };

            await _context.Pizzas.AddAsync(pizzaEntity);
            await _context.SaveChangesAsync();

            return pizzaEntity.Id;
        }



    }
}
