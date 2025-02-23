using BookLibraryCleanArchitecture.Server.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryCleanArchitecture.Server.Entities.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData
            (
                new Book() { Id = 1, Title = "Kafka on the shore", Genre = "Fiction-SF", ISBN = "978-606-123-1", LoanedQuantity = 0, NumberOfCopies = 3, NumberOfPages = 505, Publisher = "Klim", ReleaseYear = 2007 },
                new Book() { Id = 2, Title = "1Q84", Genre = "Fiction-Romance", ISBN = "093-184-732-2", LoanedQuantity = 0, NumberOfCopies = 4, NumberOfPages = 808, Publisher = "Klim", ReleaseYear = 2011 },
                new Book() { Id = 3, Title = "Rodby-Puttgarden", Genre = "Fiction-Thriller", LoanedQuantity = 0, ISBN = "731-847-427-0", NumberOfCopies = 3, Publisher = "Samleren", ReleaseYear = 2011 },
                new Book() { Id = 4, Title = "Maigret", Genre = "Fiction-Crime", ISBN = "743-263-482-8", LoanedQuantity = 0, NumberOfCopies = 5, NumberOfPages = 144, Publisher = "Lindhart op Linghorf", ReleaseYear = 2011 },
                new Book() { Id = 5, Title = "Database System Concenpts 6th Edition", Genre = "NonFiction-Textbook", ISBN = "943-921-813-0", LoanedQuantity = 0, NumberOfCopies = 10, NumberOfPages = 505, Publisher = "McGraw-Hill", ReleaseYear = 2010 },
                new Book() { Id = 7, Title = "Windows 8.1-Effectiv udden touch", ISBN = "453-263-283-4", Publisher = "Textmaster", ReleaseYear = 2014, Genre = "NonFiction-Guide", NumberOfCopies = 5, LoanedQuantity = 0, NumberOfPages = 255 },
                new Book() { Id = 8, Title = "The New York Triogy", Publisher = "Faber and Faber", ISBN = "253-273-284-9", ReleaseYear = 1985, Genre = "Fiction-Crime", NumberOfCopies = 3, LoanedQuantity = 0, NumberOfPages = 458 }
            );
        }
    }
}
