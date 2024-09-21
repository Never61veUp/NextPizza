using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPizza.Persistence.Entities
{
    public class ProductEntity : Entity
    {
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public bool IsNewProduct { get; set; }
    }
}
