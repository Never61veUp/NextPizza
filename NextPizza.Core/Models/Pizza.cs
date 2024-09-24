using CSharpFunctionalExtensions;

namespace NextPizza.Core.Models;

public class Pizza : Product
{
    private Pizza(Guid id, string title, decimal price, bool isNewProduct, string imageUrl,
        IReadOnlyList<string> ingredients,
        Size size, bool isVegan, DoughType doughType)
        : base(id, title, price, isNewProduct, imageUrl, "pizza")
    {
        Ingredients = ingredients;
        Size = size;
        IsVegan = isVegan;
        DoughType = doughType;
    }

    private Pizza(string title, decimal price, bool isNewProduct, string imageUrl, IReadOnlyList<string> ingredients,
        Size size, bool isVegan, DoughType doughType)
        : base(title, price, isNewProduct, imageUrl, "pizza")
    {
        Ingredients = ingredients;
        Size = size;
        IsVegan = isVegan;
        DoughType = doughType;
    }

    public IReadOnlyList<string> Ingredients { get; }
    public bool IsVegan { get; }
    public DoughType DoughType { get; }
    public Size Size { get; }

    public static Result<Pizza> CreateExisting(Guid id, string title, decimal price, bool isNewProduct, string imageUrl,
        IReadOnlyList<string> ingredients, Size size, DoughType doughType, bool isVegan)
    {
        if (string.IsNullOrWhiteSpace(title) || title.Length > MAX_TITLE_LENGTH)
            return Result.Failure<Pizza>("Title is invalid or too long.");

        if (ingredients.Count == 0) return Result.Failure<Pizza>("Ingredients cannot be empty.");

        if (price <= 0) return Result.Failure<Pizza>("Price must be greater than zero.");

        var pizza = new Pizza(id, title, price, isNewProduct, imageUrl, ingredients, size, isVegan, doughType);
        return Result.Success(pizza);
    }

    public static Result<Pizza> CreateNew(string title, decimal price, bool isNewProduct, string imageUrl,
        IReadOnlyList<string> ingredients, Size size, DoughType doughType, bool isVegan)
    {
        if (string.IsNullOrWhiteSpace(title) || title.Length > MAX_TITLE_LENGTH)
            return Result.Failure<Pizza>("Title is invalid or too long.");

        if (ingredients.Count == 0) return Result.Failure<Pizza>("Ingredients cannot be empty.");

        if (price <= 0) return Result.Failure<Pizza>("Price must be greater than zero.");

        var pizza = new Pizza(title, price, isNewProduct, imageUrl, ingredients, size, isVegan, doughType);
        return Result.Success(pizza);
    }
}