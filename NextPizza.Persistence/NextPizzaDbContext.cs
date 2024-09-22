using Microsoft.EntityFrameworkCore;
using NextPizza.Persistence.Entities;

namespace NextPizza.Persistence
{
    public class NextPizzaDbContext : DbContext
    {
        public NextPizzaDbContext(DbContextOptions<NextPizzaDbContext> options)
            : base(options)
        {

        }

        
        public DbSet<SizeEntity> Sizes { get; set; }
        public DbSet<DoughTypeEntity> DoughTypes { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<PizzaEntity> Pizzas { get; set; }
        public DbSet<DrinkEntity> Drinks { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // Настройка наследования через TPH
        //    modelBuilder.Entity<ProductEntity>()
        //        .HasDiscriminator<string>("ProductType")
        //        .HasValue<PizzaEntity>("Pizza")
        //        .HasValue<DrinkEntity>("Drink");

        //    // Дополнительные конфигурации для конкретных продуктов
        //    modelBuilder.Entity<PizzaEntity>()
        //        .Property(p => p.DoughTypeId)
        //        .IsRequired();

        //    modelBuilder.Entity<DrinkEntity>()
        //        .Property(d => d.VolumeInLiters)
        //        .IsRequired();
        //}
    }
}
