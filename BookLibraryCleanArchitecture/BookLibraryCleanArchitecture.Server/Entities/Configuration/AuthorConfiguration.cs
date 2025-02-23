using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BookLibraryCleanArchitecture.Server.Entities.Models;

namespace BookLibraryCleanArchitecture.Server.Entities.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasData
            (
                new Author() { Id = 1, Name = "Haruki Murakami", Country = "Japan" },
                new Author() { Id = 2, Name = "Helle Helle", Country = "Denmark" },
                new Author() { Id = 3, Name = "Georges Simenon", Country = "Belgium" },
                new Author() { Id = 4, Name = "Martin Simon", Country = "Denmark" },
                new Author() { Id = 5, Name = "Avi Silberchatz", Country = "USA" },
                new Author() { Id = 6, Name = "Paul Auster", Country = "USA" }
            );
        }
    }
}
