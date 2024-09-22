using System.ComponentModel.DataAnnotations.Schema;

namespace NextPizza.Persistence.Entities
{
    [Table("Pizza")]
    public class PizzaEntity : ProductEntity
    //подумать о продукте
    {
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
