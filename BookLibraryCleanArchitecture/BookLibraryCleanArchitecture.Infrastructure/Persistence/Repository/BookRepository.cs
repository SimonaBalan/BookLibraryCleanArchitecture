using BookLibraryCleanArchitecture.Domain.BookAggregate;
using BookLibraryCleanArchitecture.Domain.BookAggregate.Entities;
using BookLibraryCleanArchitecture.Domain.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;


namespace BookLibraryCleanArchitecture.Infrastructure.Persistence.Repository
{
    public class BookRepository : IBookRepository
    {
        private ApplicationDbContext _context;     
        private IAuthorRepository _authorRepository;

        public BookRepository(ApplicationDbContext context, IAuthorRepository authorRepository)
        {
            _context = context;
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> CreateBookAsync(Book newBook, IEnumerable<int> authorIds)
        {
            using (var dbTransaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.Books.AddAsync(newBook);
                    _context.Entry(newBook).State = EntityState.Added;
                    await _context.SaveChangesAsync();

                    foreach (var authorId in authorIds)
                    {
                        var author = await _authorRepository.GetAuthorByIdAsync(authorId);
                        if (author != null)
                        {
                            var bookAuthor = AuthorBook.CreateNew(newBook.Id, author.Id);
                            
                            _context.BookAuthors.Add(bookAuthor);
                        }
                    }
                    await _context.SaveChangesAsync();
                    await dbTransaction.CommitAsync();
                    return await _context.Books.FindAsync(newBook.Id);
                }
                catch (Exception ex)
                {
                    await dbTransaction.RollbackAsync();
                    throw;
                }
            }
        }
    }
}
