using BookLibraryCleanArchitecture.Application.Entities.DataTransferObjects;
using BookLibraryCleanArchitecture.Shared.Errors;
using CSharpFunctionalExtensions;
using MediatR;


namespace BookLibraryCleanArchitecture.Application.Books.Queries.GetBooksList
{
    public record GetBooksListQuery() : IRequest<Result<IEnumerable<BookDto>, Error>>;
}
