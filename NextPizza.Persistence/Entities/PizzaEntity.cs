using System.ComponentModel.DataAnnotations.Schema;

namespace NextPizza.Persistence.Entities
{
    public class PizzaEntity : Entity
    //подумать о продукте
    {

        public string? Title { get; set; }
        public decimal Price { get; set; }
        public bool IsNewProduct { get; set; }
        //public List<string> Ingredients { get; }
        public bool IsVegan { get; set; }
        public Guid DoughTypeId { get; set; }
        [ForeignKey("DoughTypeId")]
        public DoughTypeEntity DoughType { get; set; }

        public Guid SizeId { get; set; }
        [ForeignKey("SizeId")]
        public SizeEntity SizeEntity { get; set; }
    }
}
