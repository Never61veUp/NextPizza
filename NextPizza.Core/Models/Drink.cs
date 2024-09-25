using CSharpFunctionalExtensions;

namespace NextPizza.Core.Models;

public class Drink : Product
{
    private Drink(Guid id, string title, decimal price, bool isNewProduct, string imageUrl,
        bool isAlcoholic, decimal volumeInLiters)
        : base(title, price, isNewProduct, imageUrl, "Drink")
    {
        VolumeInLiters = volumeInLiters;
        IsAlcoholic = isAlcoholic;
    }

    private Drink(string title, decimal price, bool isNewProduct, string imageUrl, bool isAlcoholic,
        decimal volumeInLiters)
        : base(title, price, isNewProduct, imageUrl, "Drink")
    {
        VolumeInLiters = volumeInLiters;
        IsAlcoholic = isAlcoholic;
    }

    public decimal VolumeInLiters { get; set; }
    public bool IsAlcoholic { get; set; }

    public static Result<Drink> CreateNew(string title, decimal price, bool isNewProduct, string imageUrl, 
        bool isAlcoholic, decimal volumeInLiters)
    {
        if (CheckResult(title, price, out var existing, volumeInLiters, isAlcoholic)) return existing;
        var drink = new Drink(title, price, isNewProduct, imageUrl, isAlcoholic, volumeInLiters);
        return drink;
    }

    public static Result<Drink> CreateExisting(Guid id, string title, decimal price, bool isNewProduct, string imageUrl,
        bool isAlcoholic, decimal volumeInLiters)
    {
        if (CheckResult(title, price, out var existing, volumeInLiters, isAlcoholic)) return existing;
        var drink = new Drink(id, title, price, isNewProduct, imageUrl, isAlcoholic, volumeInLiters);
        return drink;
    }

    protected static bool CheckResult(string title, decimal price, out Result<Drink> exceptionResult, decimal volumeInLiters, bool isAlcohol)
    {
        if(CheckProductException(title, price, out var productExceptionResult))
        {
            exceptionResult = productExceptionResult.Map(product => (Drink)product);
            return true;
        }
        exceptionResult = Result.Failure<Drink>("Something went wrong.");

        if (volumeInLiters >= 10)
        {
            exceptionResult = Result.Failure<Drink>($"The maximum permitted drink volume is { MAX_DRINK_VOLUME } liters");
            return true;
        }

        return false;
    }
}