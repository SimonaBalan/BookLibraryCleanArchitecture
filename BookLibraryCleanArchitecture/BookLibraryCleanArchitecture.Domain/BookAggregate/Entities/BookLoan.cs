using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BookLibraryCleanArchitecture.Domain.Common;

namespace BookLibraryCleanArchitecture.Domain.BookAggregate.Entities
{
    public class BookLoan : AuditableAggregate
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        public DateTime BorrowedDate { get; set; }

        public DateTime? ReturnedDate { get; set; }

        public DateTime DueDate { get; set; }

        public LoanStatus Status { get; set; }

        public static BookLoan Create(int bookId, string userId, DateTime borrowedDate, DateTime? returnedDate,
            DateTime dueDate, LoanStatus status)
        {
            return new BookLoan
            {
                BookId = bookId,
                UserId = userId,
                BorrowedDate = borrowedDate,
                DueDate = dueDate,
                ReturnedDate = returnedDate,
                Status = LoanStatus.Active
            };
        }
    }

    public enum LoanStatus
    {
        Active = 0,
        Renewed = 1,
        Finalized
    }
}
