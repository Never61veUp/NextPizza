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

        public DbSet<PizzaEntity> Pizzas { get; set; }
        public DbSet<SizeEntity> Sizes { get; set; }
        public DbSet<DoughTypeEntity> DoughTypes { get; set; }
    }
}
