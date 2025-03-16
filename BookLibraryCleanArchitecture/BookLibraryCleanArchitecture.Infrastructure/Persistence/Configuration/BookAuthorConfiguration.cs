using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BookLibraryCleanArchitecture.Domain.BookAggregate.Entities;

namespace BookLibraryCleanArchitecture.Server.Entities.Configuration
{
    public class BookAuthorConfiguration : IEntityTypeConfiguration<AuthorBook>
    {
        public void Configure(EntityTypeBuilder<AuthorBook> builder)
        {
            builder.HasData
            (
                AuthorBook.Create(1, 1, DateTime.Now),
                AuthorBook.Create(1, 2, DateTime.Now),
                AuthorBook.Create(2, 3, DateTime.Now),
                AuthorBook.Create(2, 4, DateTime.Now),
                AuthorBook.Create(3, 5, DateTime.Now),
                AuthorBook.Create(5, 7, DateTime.Now),
                AuthorBook.Create(6, 6, DateTime.Now)
            );
        }
    }
}
