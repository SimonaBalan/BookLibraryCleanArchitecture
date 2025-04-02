using BookLibraryCleanArchitecture.Application.Entities.DataTransferObjects;
using BookLibraryCleanArchitecture.Shared.Errors;
using CSharpFunctionalExtensions;
using MediatR;

namespace BookLibraryCleanArchitecture.Application.Books.Commands.CreateBook
{
    public record CreateBookCommand(BookDto Book, IEnumerable<int> Authors) : IRequest<Result<BookDto, Error>>;
    
}
