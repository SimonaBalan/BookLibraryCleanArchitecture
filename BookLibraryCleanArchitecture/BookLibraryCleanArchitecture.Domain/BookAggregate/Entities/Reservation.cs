using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BookLibraryCleanArchitecture.Domain.Common;

namespace BookLibraryCleanArchitecture.Domain.BookAggregate.Entities
{
    public class Reservation : AuditableAggregate
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }

        public DateTime ReservedDate { get; set; }

        public ReservationStatus Status { get; set; }

        public static Reservation Create(string userId, int bookId, DateTime reservedDate, ReservationStatus status)
        {
            return new Reservation
            {
                UserId = userId,
                BookId = bookId,
                ReservedDate = reservedDate,
                Status = status
            };
        }
    }

    public enum ReservationStatus
    {
        Active = 0,
        Finalized = 1,
        Cancelled = 2,
        Expired = 3
    }
}
