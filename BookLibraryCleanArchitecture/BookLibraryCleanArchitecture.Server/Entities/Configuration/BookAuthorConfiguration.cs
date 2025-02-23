using BookLibraryCleanArchitecture.Server.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryCleanArchitecture.Server.Entities.Configuration
{
    public class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.HasData
            (
                new BookAuthor() { AuthorId = 1, BookId = 1 },
                new BookAuthor() { AuthorId = 1, BookId = 2 },
                new BookAuthor() { AuthorId = 2, BookId = 3 },
                new BookAuthor() { AuthorId = 2, BookId = 4 },
                new BookAuthor() { AuthorId = 3, BookId = 5 },
                new BookAuthor() { AuthorId = 5, BookId = 7 },
                new BookAuthor() { AuthorId = 6, BookId = 8 }
            );
        }
    }
}
