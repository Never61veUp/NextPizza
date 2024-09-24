using NextPizza.Core.Models;

namespace NextPizza.API.Contracts
{
    public record ProductRequest (
        string Title,
        decimal Price,
        bool IsNewProduct,
        bool IsVegan,
        string Type,
        Guid DoughTypeId,
        Guid SizeId,
        decimal VolumeInLiters,
        bool IsAlcoholic
        );

}
