using BookLibraryCleanArchitecture.Domain.BookAggregate;
using FluentValidation;


namespace BookLibraryCleanArchitecture.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(b => b.Book.Title).NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage($"{nameof(Book.Title)} must not exceed 50 characters");

            RuleFor(b => b.Book.ISBN).NotEmpty().WithMessage($"{nameof(Book.ISBN)} is required")
                .NotNull();

            RuleFor(b => b.Book.Publisher).NotEmpty().WithMessage($"{nameof(Book.Publisher)} is required")
                .NotNull();

            RuleFor(b => b.Book.ReleaseYear).NotEmpty().WithMessage($"{nameof(Book.ReleaseYear)} is required")
                .NotNull()
                .GreaterThan(0).WithMessage($"{nameof(Book.ReleaseYear)} must be greater than 0");

            RuleFor(b => b.Book.Genre).NotEmpty().WithMessage($"{nameof(Book.Genre)} is required")
                .NotNull();

            RuleFor(b => b.Book.Status).NotNull().WithMessage($"{nameof(Book.Status)} is required");

            RuleFor(b => b.Book.NumberOfCopies).NotNull().WithMessage($"{nameof(Book.NumberOfCopies)} is required")
                .NotNull()
                .GreaterThan(0).WithMessage($" must be greater than 0");

            RuleFor(b => b.Book.LoanedQuantity)
                .NotNull()
                .GreaterThanOrEqualTo(0).WithMessage($"Invalid loaned quantity");

            RuleFor(b => b.Book.NumberOfPages).NotEmpty().WithMessage($"{nameof(Book.NumberOfPages)} is required")
                .NotNull()
                .GreaterThan(0).WithMessage($"Invalid number of pages");

            //RuleFor(a => a.Authors).NotNull().WithMessage("Authors cannot be null")
                //.Must(authors => authors != null && authors.Any()).WithMessage("Authors must contain at least one item!");
        }
    }
    /*public class AuthorsForCreateBookValidator : AbstractValidator<List<AuthorBookCommand>>
    {
        public AuthorsForCreateBookValidator()
        {
            RuleFor(a => a).ForEach(a =>
            {
                a.NotNull().WithMessage("Author cannot be null").SetValidator(new AuthorForCreateBookValidator());
            });
        }
    }*/
}
