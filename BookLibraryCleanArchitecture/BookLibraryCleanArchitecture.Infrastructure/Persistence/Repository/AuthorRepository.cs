using BookLibraryCleanArchitecture.Domain.BookAggregate.Entities;
using BookLibraryCleanArchitecture.Domain.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;


namespace BookLibraryCleanArchitecture.Infrastructure.Persistence.Repository
{
    public class AuthorRepository(ApplicationDbContext applicationDbContext) : IAuthorRepository
    {
        private readonly ApplicationDbContext _context;

        public Task<Author> AddAuthorAsync(Author author)
        {
            throw new NotImplementedException();
        }

        public Task<Author> DeleteAuthorAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            return await _context.Authors.AsNoTracking()                    
                    .FirstAsync(ent => ent.Id.Equals(id));
        }

        public Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Author> UpdateAuthorAsync(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
