

using BookLibraryCleanArchitecture.Domain.BookAggregate;

namespace BookLibraryCleanArchitecture.Domain.Contracts.Persistence
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();

        Task<Book> CreateBookAsync(Book newBook, IEnumerable<int> authorIds);
    }
}
