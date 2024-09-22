namespace NextPizza.Core.Models;

public abstract class Product
{
    public const int MAX_TITLE_LENGTH = 50;

    protected Product(string title, decimal price, bool isNewProduct, string imageUrl, string type)
    {
        Id = Guid.NewGuid();
        Title = title;
        Price = price;
        IsNewProduct = isNewProduct;
        ImageUrl = imageUrl;
        Type = type;
    }

    protected Product(Guid id, string title, decimal price, bool isNewProduct, string imageUrl, string type)
    {
        Id = id;
        Title = title;
        Price = price;
        IsNewProduct = isNewProduct;
        ImageUrl = imageUrl;
        Type = type;
    }

    public Guid Id { get; protected set; }
    public string Title { get; protected set; } = string.Empty;
    public decimal Price { get; protected set; }
    public bool IsNewProduct { get; protected set; }
    public string? ImageUrl { get; protected set; }
    public string Type { get; protected set; }
}