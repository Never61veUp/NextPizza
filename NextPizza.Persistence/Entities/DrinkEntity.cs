using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPizza.Persistence.Entities
{
    public class DrinkEntity : ProductEntity
    {
        public decimal VolumeInLiters { get; set; }
        public bool IsAlcoholic { get; set; }
    }
}
