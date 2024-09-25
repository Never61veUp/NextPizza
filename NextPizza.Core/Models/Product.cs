using CSharpFunctionalExtensions;

namespace NextPizza.Core.Models;

public abstract class Product
{
    public const int MAX_TITLE_LENGTH = 50;
    public const int MAX_DRINK_VOLUME = 2;

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

    private static bool IsValidTitle(string str)
    {
        return str.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
    }

    protected static bool CheckProductException(string title, decimal price, out Result<Product> exceptionResult)
    {
        exceptionResult = Result.Failure<Product>("Something went wrong.");
        if (string.IsNullOrWhiteSpace(title))
        {
            exceptionResult = Result.Failure<Product>("Title cannot be empty.");
            return true;
        }

        if (title.Length > MAX_TITLE_LENGTH)
        {
            exceptionResult =
                Result.Failure<Product>($"Title exceeds the maximum length of {MAX_TITLE_LENGTH} characters.");
            return true;
        }

        if (!Product.IsValidTitle(title))
        {
            exceptionResult = Result.Failure<Product>("Title contains invalid characters.");
            return true;
        }
        if (price <= 0)
        {
            exceptionResult = Result.Failure<Product>("Price must be greater than zero.");
            return true;
        }

        return false;
    }
}