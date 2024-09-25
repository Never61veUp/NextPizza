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
        if (CheckResult(title, price, ingredients, out var exception)) return exception;

        var pizza = new Pizza(id, title, price, isNewProduct, imageUrl, ingredients, size, isVegan, doughType);
        return Result.Success(pizza);
    }

    public static Result<Pizza> CreateNew(string title, decimal price, bool isNewProduct, string imageUrl,
        IReadOnlyList<string> ingredients, Size size, DoughType doughType, bool isVegan)
    {
        if (CheckResult(title, price, ingredients, out var existing)) return existing;

        var pizza = new Pizza(title, price, isNewProduct, imageUrl, ingredients, size, isVegan, doughType);
        return Result.Success(pizza);
    }

    private static bool CheckResult(string title, decimal price, IReadOnlyList<string> ingredients,
        out Result<Pizza> exceptionResult)
    {
        if (CheckProductException(title, price, out var productExceptionResult))
        {
            exceptionResult = productExceptionResult.Map(product => (Pizza)product);
            return true;
        }

        exceptionResult = Result.Failure<Pizza>("Something went wrong.");


        if (ingredients == null || ingredients.Count == 0)
        {
            exceptionResult = Result.Failure<Pizza>("Ingredients cannot be null or empty.");
            return true;
        }

        if (ingredients.Distinct().Count() != ingredients.Count)
        {
            exceptionResult = Result.Failure<Pizza>("Ingredients must be unique.");
            return true;
        }

        return false;
    }
}