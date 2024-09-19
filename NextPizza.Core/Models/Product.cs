using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPizza.Core.Models
{
    public abstract class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public bool IsNewProduct { get; set; }
        public string ImageUrl { get; set; }
    }
}
