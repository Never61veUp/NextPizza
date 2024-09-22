namespace NextPizza.Core.Models
{
    public abstract class Product
    {
        public Guid Id { get; protected set; }
        public string Title { get; protected set; } = string.Empty;
        public decimal Price { get; protected set; }
        public bool IsNewProduct { get; protected set; }
        public string? ImageUrl { get; protected set; }
        public string Type { get; protected set; }
    }
}
