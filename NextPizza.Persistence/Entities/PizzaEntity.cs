using System.ComponentModel.DataAnnotations.Schema;
using NextPizza.Core.Models;

namespace NextPizza.Persistence.Entities
{
    [Table("Pizza")]
    public class PizzaEntity : ProductEntity
    {
        //public List<string> Ingredients { get; }
        public bool IsVegan { get; set; }
        public Guid DoughTypeId { get; set; }
        [ForeignKey("DoughTypeId")]
        public DoughTypeEntity DoughTypeEntity { get; set; }
        public Guid SizeId { get; set; }
        [ForeignKey("SizeId")]
        public SizeEntity SizeEntity { get; set; }

        private List<string> a = new List<string>()
        {
            "d"
        };

        protected override Product CreateExtended(ProductEntity product)
        {
            return Pizza.CreateExisting(Id, Title, Price, IsNewProduct, "", a, );
        }
    }
}
