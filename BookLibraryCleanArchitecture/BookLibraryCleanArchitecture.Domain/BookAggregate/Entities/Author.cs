using BookLibraryCleanArchitecture.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLibraryCleanArchitecture.Domain.BookAggregate.Entities
{
    public class Author : AuditableAggregate
    {
        private readonly IList<Book> _books = new List<Book>();
        private readonly IList<AuthorBook> _authorBooks = new List<AuthorBook>();

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Country { get; private set; }

        public virtual IReadOnlyList<Book> Books => _books.ToList();
        public virtual IReadOnlyList<AuthorBook> BookAuthors => _authorBooks.ToList();

        private Author() { } // for ef core

        private Author(int id, string name, string country)
        {
            Id = id;
            Name = name;
            Country = country;
        }

        public static Author Create(int id, string name, string country) => new(id, name, country);
        public void AddBook(Book book)
        {
            _books.Add(book);
        }
    }
}
