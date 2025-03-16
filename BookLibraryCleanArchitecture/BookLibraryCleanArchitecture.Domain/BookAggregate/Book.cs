using BookLibraryCleanArchitecture.Domain.BookAggregate.Entities;
using BookLibraryCleanArchitecture.Domain.BookAggregate.Events;
using BookLibraryCleanArchitecture.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookLibraryCleanArchitecture.Domain.BookAggregate
{
    public class Book : AuditableAggregate
    {
        private readonly IList<Author> _authors = new List<Author>();
        private readonly IList<BookLoan> _loans = new List<BookLoan>();
        private readonly IList<Reservation> _reservations = new List<Reservation>();
        private readonly IList<WaitingList> _waitingList = new List<WaitingList>();
        private readonly IList<AuthorBook> _authorBooks = new List<AuthorBook>();

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ISBN { get; private set; }
        public string Title { get; private set; }
        public string Publisher { get; private set; }

        public int ReleaseYear { get; private set; }

        public string Genre { get; private set; }

        public BookStatus Status { get; private set; }

        public int NumberOfCopies { get; private set; }

        public int LoanedQuantity { get; private set; }

        public int NumberOfPages { get; private set; }

        [Timestamp]
        public byte[] Version { get; private set; }

        public virtual IReadOnlyList<Author> Authors => _authors.ToList();

        [JsonIgnore, NotMapped]
        public virtual IReadOnlyList<AuthorBook> BookAuthors => _authorBooks.ToList();

        public virtual IReadOnlyList<BookLoan> Loans => _loans.ToList();

        public virtual IReadOnlyList<Reservation> Reservations => _reservations.ToList();

        public virtual IReadOnlyList<WaitingList> WaitingList => _waitingList.ToList();

        private Book() { } // for ef core

        private Book(int id, string title, string isbn, string publisher, int releaseYear, string genre, 
            BookStatus status, int noOfCopies, int loanedQuantity, int noOfPages)
        {
            Id = id;
            Title = title;
            ISBN = isbn;
            Publisher = publisher;
            ReleaseYear = releaseYear;
            Genre = genre;
            Status = status;
            NumberOfCopies = noOfCopies;
            LoanedQuantity = loanedQuantity;
            NumberOfPages = noOfPages;
        }

        public static Book Create(int id, string title, string isbn, string publisher,
            int releaseYear, string genre, BookStatus status, int noOfCopies, int loanedQuantity, int noOfPages)
        {
            Book book = new(id, title, isbn, publisher, releaseYear, genre, status, noOfCopies, loanedQuantity, noOfPages);
            book.AddDomainEvent(new BookCreatedEvent(book));
            return book;
        }

        public void AddAuthor(Author author)
        {
            _authors.Add(author);
            author.AddBook(this);
        }
    }

    public enum BookStatus
    {
        Available = 0,
        Lost
    }
}
