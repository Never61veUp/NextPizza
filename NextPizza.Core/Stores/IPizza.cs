using NextPizza.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPizza.Core.Stores
{
    public interface IPizza
    {
        Task<Pizza> GetById(Guid id);
        Task<Pizza> GetByName(string name);
        Task<IEnumerable<Pizza>> GetAll();
        Task DeleteById(Guid id);
        Task Add(Pizza pizza);
    }
}
