using CSharpFunctionalExtensions;
namespace NextPizza.Core.Models
{
    public class Size
    {
        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public int SizeInCm { get; }

        private Size(string title, int sizeInCm)
        {
            Id = Guid.NewGuid();
            Title = title;
            SizeInCm = sizeInCm;
        }
        private Size(Guid id, string title, int sizeInCm)
        {
            Id = id;
            Title = title;
            SizeInCm = sizeInCm;
        }
        public static Result<Size> CreateNew(string title, int sizeInCm)
        {
            if (string.IsNullOrWhiteSpace(title))
                return Result.Failure<Size>("Title cannot be empty");
            if (sizeInCm <= 0)
                return Result.Failure<Size>("Size must be greater than 0");

            return Result.Success(new Size(Guid.NewGuid(), title, sizeInCm));
        }

        public static Result<Size> CreateExisting(Guid id, string title, int sizeInCm)
        {
            return new Size(id, title, sizeInCm);
        }

    }
}
