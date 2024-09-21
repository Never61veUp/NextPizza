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
        private DoughType(string title, int thicknessInCm)
        {
            Id = Guid.NewGuid();
            Title = title;
            ThicknessInCm = thicknessInCm;
        }

        public static Result<DoughType> CreateExisting(Guid id, string title, int thicknessInCm)
        {
            var result = new DoughType(id, title, thicknessInCm);
            //validation
            return Result.Success(result);
        }
        public static Result<DoughType> CreateNew(string title, int thicknessInCm)
        {
            var result = new DoughType(title, thicknessInCm);
            //validation
            return Result.Success(result);
        }
    }
}
