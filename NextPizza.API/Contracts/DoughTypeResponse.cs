namespace NextPizza.API.Contracts
{
    public record DoughTypeResponse(
        Guid Id,
        string Title,
        int ThicknessInCm
        );
}
