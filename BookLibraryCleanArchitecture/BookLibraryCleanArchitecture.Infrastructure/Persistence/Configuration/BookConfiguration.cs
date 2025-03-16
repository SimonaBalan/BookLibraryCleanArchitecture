using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BookLibraryCleanArchitecture.Domain.BookAggregate;

namespace BookLibraryCleanArchitecture.Server.Entities.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData
            (
                Book.Create(1, "Kafka on the shore", "978-606-123-1", "Klim", 2007, "Fiction-SF", 0, 3, 0, 505),
                Book.Create(2, "1Q84", "093-184-732-2", "Klim", 2011, "Fiction-Romance", 0, 4, 0, 808),
                Book.Create(3, "Rodby-Puttgarden", "731-847-427-0", "Samleren", 2011, "Fiction-Thriller", 0, 3, 0, 400),
                Book.Create(4, "Maigret", "743-263-482-8", "Lindhart op Linghorf", 2011, "Fiction -Crime", 0, 5, 0, 144),
                Book.Create(5, "Database System Concenpts 6th Edition", "943-921-813-0", "McGraw-Hill", 2010, "NonFiction-Textbook", 0, 10, 0, 505),
                Book.Create(6, "Windows 8.1-Effectiv udden touch", "453-263-283-4", "Textmaster", 2014, "NonFiction-Guide", 0, 5, 0, 255),
                Book.Create(7, "The New York Triogy", "253-273-284-9", "Faber and Faber", 1985, "Fiction-Crime", 0, 3, 0, 458)
            );
        }
    }
}
