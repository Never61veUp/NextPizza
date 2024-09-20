using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPizza.Core.Models
{
    public abstract class Product
    {
        public Guid Id { get; protected set; }
        public string Title { get; protected set; } = string.Empty;
        public decimal Price { get; protected set; }
        public bool IsNewProduct { get; protected set; }
        public string? ImageUrl { get; protected set; }
    }
}
