using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextPizza.Core.Models;
using NextPizza.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPizza.Persistence.Configurations
{
    internal class PizzaConfiguration : IEntityTypeConfiguration<PizzaEntity>
    {
        public void Configure(EntityTypeBuilder<PizzaEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .HasMaxLength(Pizza.MAX_TITLE_LENGTH)
                .IsRequired();
            builder.Property(x => x.IsNewProduct).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.DoughType).IsRequired();
            builder.Property(x => x.Size).IsRequired();
            builder.Property(x => x.IsVegan).IsRequired();

            

        }
    }
}
