using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using NextPizza.Core.Abstractions;
using NextPizza.Core.Models;
using NextPizza.Persistence.Entities;

namespace NextPizza.Persistence.Repositories;

public class ProductsRepository : IProductsRepository

//подумать о продукте
{
    private readonly NextPizzaDbContext _context;

    public ProductsRepository(NextPizzaDbContext context)
    {
        _context = context;
    }


    public async Task<Result<IEnumerable<Product>>> GetAllProducts()
    {
        DrinkEntity drink = new DrinkEntity();
        var b = new List<string>()
        {
            "d"
        };
        var getProducts = await _context.Products.ToListAsync();

        var a = getProducts.Select(p => drink.ToDrink(getProducts.)).ToList();

        foreach (var VARIABLE in getProducts)
        {
            VARIABLE.To
        }





        //var pizzaEntities = await _context.Pizzas.AsNoTracking().Include(pizzaEntity => pizzaEntity.SizeEntity)
        //    .Include(pizzaEntity => pizzaEntity.DoughTypeEntity).ToListAsync();

        //var drinkEntities = await _context.Drinks.AsNoTracking().ToListAsync();



        //IEnumerable<Product> combinedList = drinkEntities
        //    .Select(d => (Product)Drink.CreateExisting(d.Id, d.Title, d.Price, d.IsNewProduct, imageUrl: "", d.IsAlcoholic, d.VolumeInLiters).Value)
        //    .Concat(
        //        pizzaEntities.Select(p => (Product)Pizza.CreateExisting(p.Id, p.Title, p.Price, p.IsNewProduct, imageUrl: "", b, _context.Sizes.Where(x => x.Id == p.DoughTypeId)
        //            .Select(b => Size.CreateExisting(b.Id, b.Title, b.SizeInCm).Value).FirstOrDefault(), _context.DoughTypes
        //            .Where(x => x.Id == p.DoughTypeId)
        //            .Select(b => DoughType.CreateExisting(b.Id, b.Title, b.ThicknessInCm).Value).FirstOrDefault(), p.IsVegan).Value)
        //    );

        //return Result.Success<IEnumerable<Product>>(combinedList);
    }


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
                SizeId = pizza.Size.Id
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
                VolumeInLiters = drink.VolumeInLiters
            };
            await _context.Drinks.AddAsync(drinkEntity);
            await _context.SaveChangesAsync();
        }


        return Result.Success(product);
    }
}