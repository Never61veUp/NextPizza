using NextPizza.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPizza.Core.Abstractions
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Pizza>> Get();
        Task<Guid> Create(Pizza pizza);
    }
}
