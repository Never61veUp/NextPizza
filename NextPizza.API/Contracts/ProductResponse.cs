namespace NextPizza.API.Contracts
{
    public record ProductResponse(
        Guid Id,
        string Title,
        decimal Price
        );

}
