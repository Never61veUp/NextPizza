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



        public async Task<Result<Product>> CreatePizza(Product product)
        {
            if (product.Type == "pizza")
            {
                var pizza = product as Pizza;
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
            }
            else
            {
                var drink = product as Drink;
                var drinkEntity = new DrinkEntity
                {
                    Id = drink.Id,
                    Title = drink.Title,
                    Price = drink.Price,
                    IsNewProduct = drink.IsNewProduct,
                    IsAlcoholic = drink.IsAlcoholic,
                    VolumeInLiters = drink.VolumeInLiters,
                };
                await _context.Drinks.AddAsync(drinkEntity);
                await _context.SaveChangesAsync();
            }
           

            return Result.Success(product);
            
        }


    }
}
