using NextPizza.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPizza.Persistence.Entities
{
    [Table("Drink")]
    public class DrinkEntity : ProductEntity
    {
        public decimal VolumeInLiters { get; set; }
        public bool IsAlcoholic { get; set; }

    }

    
}
