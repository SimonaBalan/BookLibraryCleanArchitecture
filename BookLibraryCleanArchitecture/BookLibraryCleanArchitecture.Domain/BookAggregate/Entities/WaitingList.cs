using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BookLibraryCleanArchitecture.Domain.Common;

namespace BookLibraryCleanArchitecture.Domain.BookAggregate.Entities
{
    public class WaitingList : AuditableAggregate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }

        public DateTime DateCreated { get; set; }

        public int Position { get; set; }

        public static WaitingList Create(string userId, int bookId, DateTime dateCreated, int position)
        {
            return new WaitingList
            {
                UserId = userId,
                BookId = bookId,
                DateCreated = dateCreated,
                Position = position
            };
        }
    }
}
