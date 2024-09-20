using System.ComponentModel.DataAnnotations;

namespace NextPizza.API.Contracts
{
    public record ProductRequest(
        [Required] string Title,
        [Required] decimal Price,
        [Required] bool IsNewProduct,
        [Required] string ImageUrl,
        [Required] IReadOnlyList<string> Ingredients,
        [Required] string Size
        
        )
    {

    }
}
