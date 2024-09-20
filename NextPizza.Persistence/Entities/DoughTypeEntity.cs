using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPizza.Persistence.Entities
{
    public class DoughTypeEntity : Entity
    {
        public string Title { get; set; }
        public int ThicknessInCm { get; set; }
    }
}
