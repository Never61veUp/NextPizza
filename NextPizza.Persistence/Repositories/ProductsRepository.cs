using CSharpFunctionalExtensions;
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
        public async Task<Result<Product>> Create(Product product, string type)
        {
            return Result.Success(product);

        }

        //public async Task<Result<List<Product>>> GetAllProducts()
        //{
        //    var productEntities = await _context.Products.AsNoTracking().ToListAsync();
            
        //    var products = productEntities.Se



        //}



        public async Task<Result<Pizza>> CreatePizza(Pizza pizza)
        {
            var productEntities = await _context.Products.AsNoTracking().ToListAsync();
            var pizzaEntity = new PizzaEntity
            {
                Id = pizza.Id,
                Title = pizza.Title,
                Price = pizza.Price,
                IsNewProduct = pizza.IsNewProduct,
                DoughTypeId = pizza.DoughType.Id,
                IsVegan = pizza.IsVegan,
                SizeId = pizza.Size.Id,


            };
            await _context.Pizzas.AddAsync(pizzaEntity);
            await _context.SaveChangesAsync();

            return Result.Success(pizza);
            
        }


    }
}
