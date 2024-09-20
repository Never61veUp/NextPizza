using CSharpFunctionalExtensions;
namespace NextPizza.Core.Models
{
    public class Pizza : Product
    {
        public const int MAX_TITLE_LENGTH = 50;
        public IReadOnlyList<string> Ingredients { get; }
        public bool IsVegan { get; }
        public DoughType DoughType { get; }
        public Size Size { get; }

        private Pizza(Guid id, string title, decimal price, bool isNewProduct, string imageUrl, IReadOnlyList<string> ingredients, Size size, bool isVegan, DoughType doughType)
        {
            Id = id;
            Title = title;
            Price = price;
            IsNewProduct = isNewProduct;
            ImageUrl = imageUrl;
            Ingredients = ingredients;
            Size = size;
            IsVegan = isVegan;
            DoughType = doughType;
        }
        public static Result<Pizza> Create(Guid id, string title, decimal price, bool isNewProduct, string imageUrl,
            IReadOnlyList<string> ingredients, Size size, DoughType doughType, bool isVegan)
        {

            if (string.IsNullOrWhiteSpace(title) || title.Length > MAX_TITLE_LENGTH)
            {
                return Result.Failure<Pizza>("Title is invalid or too long.");
            }

            if (ingredients.Count == 0)
            {
                return Result.Failure<Pizza>("Ingredients cannot be empty.");
            }

            if (price <= 0)
            {
                return Result.Failure<Pizza>("Price must be greater than zero.");
            }

            var pizza = new Pizza(id, title, price, isNewProduct, imageUrl, ingredients, size, isVegan, doughType);
            return Result.Success(pizza);

        }
    }

    public class Size
    {
        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public int SizeInCm { get; }

        private Size(Guid id, string title, int sizeInCm)
        {
            Id = id;
            Title = title;
            SizeInCm = sizeInCm;
        }
        public static Result<Size> Create(Guid id, string title, int sizeInCm)
        {
            var size = new Size(id, title, sizeInCm);
            //validation
            return Result.Success(size);
        }
        public static Result<Size> FindById(Guid id, string title, int sizeInCm)
        {
            var size = new Size(id, title, sizeInCm);
            //validation
            return Result.Success(size);
        }
    }

    public class DoughType
    {
        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public int ThicknessInCm { get; }

        private DoughType(Guid id, string title, int thicknessInCm)
        {
            Id = id;
            Title = title;
            ThicknessInCm = thicknessInCm;
        }
        public static Result<DoughType> Create(Guid id, string title, int thicknessInCm)
        {
            var result = new DoughType(id, title, thicknessInCm);
            //validation
            return Result.Success(result);
        }
    }
}
