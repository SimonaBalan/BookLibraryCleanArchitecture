
namespace BookLibraryCleanArchitecture.Domain.BookAggregate.Entities
{
    public class AuthorBook
    {
        public int AuthorId { get; private set; }
        public int BookId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        private AuthorBook() { } // for ef core
        private AuthorBook(int authorId, int bookId, DateTime createdAt)
        {
            AuthorId = authorId;
            BookId = bookId;
            CreatedAt = createdAt;
        }

        public static AuthorBook Create(int authorId, int bookId, DateTime createdAt) => new(authorId, bookId, createdAt);
        public static AuthorBook CreateNew(int authorId, int bookId) => new(authorId, bookId, DateTime.UtcNow);
    }
}
