using CSharpFunctionalExtensions;
namespace NextPizza.Core.Models
{
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
