using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLibraryCleanArchitecture.Server.Entities.Models
{
    public class BookAuthor
    {
        //[Key]
        //[Required]
        //public int Id { get; set; }

        [Key, Column(Order =1)]
        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        [Key,Column(Order =2)]
        [ForeignKey("Book")]
        public int BookId { get; set; }

        public virtual Book Book { get; set; } = null!;

        public virtual Author Author { get; set; } = null!;
    }
}
