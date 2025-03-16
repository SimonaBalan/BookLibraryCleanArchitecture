using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BookLibraryCleanArchitecture.Domain.BookAggregate.Entities;

namespace BookLibraryCleanArchitecture.Infrastructure.Persistence.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasData(
                Author.Create(1, "Haruki Murakami", "Japan"),
                Author.Create(2, "Helle Helle", "Denmark"),
                Author.Create(3, "Georges Simenon", "Belgium"),
                Author.Create(4, "Martin Simon", "Denmark"),
                Author.Create(5, "Avi Silberchatz", "USA"),
                Author.Create(6, "Paul Auster", "USA"));
        }
    }
}
