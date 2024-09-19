using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPizza.Persistence.Entities
{
    public class PizzaEntity
        //подумать о продукте
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public bool IsNewProduct { get; set; }
        public List<string> Ingredients { get; }
        public bool IsVegan { get; }
        public DoughType DoughType { get; }
        public Size Size { get; }
    }
}
