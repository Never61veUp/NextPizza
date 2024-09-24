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
        var drink = new Drink(title, price, isNewProduct, imageUrl, isAlcoholic, volumeInLiters);
        return drink;
    }

    public static Result<Drink> CreateExisting(Guid id, string title, decimal price, bool isNewProduct, string imageUrl,
        bool isAlcoholic, decimal volumeInLiters)
    {
        var drink = new Drink(id, title, price, isNewProduct, imageUrl, isAlcoholic, volumeInLiters);
        return drink;
    }
}