

using BookLibraryCleanArchitecture.Domain.BookAggregate.Entities;

namespace BookLibraryCleanArchitecture.Domain.Contracts.Persistence
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int id);
        Task<Author> AddAuthorAsync(Author author);
        Task<Author> UpdateAuthorAsync(Author author);
        Task<Author> DeleteAuthorAsync(int id);
    }
}
