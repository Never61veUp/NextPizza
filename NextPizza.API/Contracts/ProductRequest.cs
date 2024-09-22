using NextPizza.Core.Models;

namespace NextPizza.API.Contracts
{
    public record ProductRequest (
        string Title,
        decimal Price,
        bool IsNewProduct,
        Guid DoughTypeId,
        bool IsVegan,
        Guid SizeId
        );

}
