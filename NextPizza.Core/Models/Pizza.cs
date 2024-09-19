public enum DoughType
{
    Thin,
    Traditional
}

public enum Size
{
    Small,
    Medium,
    Large,
}



namespace NextPizza.Core.Models
{
    public class Pizza : Product
    {
        public const int MAX_TITLE_LENGTH = 50;
        public List<string> Ingredients { get; }
        public bool IsVegan { get; }
        public DoughType DoughType { get; }
        public Size Size { get; }

        private Pizza(List<string> ingredients, Size size, DoughType doughType, bool isVegan)
        {
            Ingredients = ingredients;
            Size = size;
            IsVegan = isVegan;
            DoughType = doughType;
        }
        public static (Pizza pizza, string error) Create(Guid id, List<string> ingredients, Size size, DoughType doughType, bool isVegan)
        {
            var error = string.Empty;

            if (ingredients.Count == 0)
            {
                error = "No ingredients were provided.";
            }

            var pizza = new Pizza(ingredients, size, doughType, isVegan);

            return (pizza, error);
        }
    }

}
