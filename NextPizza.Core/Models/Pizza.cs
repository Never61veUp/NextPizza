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
        if (CheckResult(title, price, ingredients, out var existing)) return existing;

        var pizza = new Pizza(id, title, price, isNewProduct, imageUrl, ingredients, size, isVegan, doughType);
        return Result.Success(pizza);
    }

    private static bool CheckResult(string title, decimal price, IReadOnlyList<string> ingredients, out Result<Pizza> existing)
    {
        existing = Result.Failure<Pizza>("Something went wrong.");
        if (string.IsNullOrWhiteSpace(title) || title.Length > MAX_TITLE_LENGTH)
        {
            existing = Result.Failure<Pizza>("Title is invalid or too long.");
            return false;
        }

        if (ingredients.Count == 0)
        {
            existing = Result.Failure<Pizza>("Ingredients cannot be empty.");
            return false;
        }

        if (price <= 0)
        {
            existing = Result.Failure<Pizza>("Price must be greater than zero.");
            return false;
        }

        return true;
    }

    public static Result<Pizza> CreateNew(string title, decimal price, bool isNewProduct, string imageUrl,
        IReadOnlyList<string> ingredients, Size size, DoughType doughType, bool isVegan)
    {
        if (CheckResult(title, price, ingredients, out var existing)) return existing;

        var pizza = new Pizza(title, price, isNewProduct, imageUrl, ingredients, size, isVegan, doughType);
        return Result.Success(pizza);
    }
}