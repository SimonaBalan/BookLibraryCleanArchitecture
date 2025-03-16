using BookLibraryCleanArchitecture.Application.Entities.DataTransferObjects;
using MediatR;

namespace BookLibraryCleanArchitecture.Application.Books.Commands.CreateBook
{
    public record CreateBookCommand(BookDto Book, IEnumerable<int> Authors) : IRequest<BookDto>;
    
}
