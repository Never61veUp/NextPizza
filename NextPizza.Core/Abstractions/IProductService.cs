using NextPizza.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPizza.Core.Abstractions
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Pizza> CreateProduct(Pizza product);
    }
}
