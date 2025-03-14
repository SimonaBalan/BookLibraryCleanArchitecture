﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookLibraryCleanArchitecture.Server.Entities.Models
{
    public class Book
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ISBN { get; set; }

        public string Title { get; set; }

        public string Publisher { get; set; }

        public int ReleaseYear { get; set; }

        public string Genre { get; set; }

        public BookStatus Status { get; set; }  

        public int NumberOfCopies { get; set; }

        public int LoanedQuantity { get; set; }

        public int NumberOfPages { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        public virtual ICollection<Author> Authors { get; set; } = new List<Author>();

        [JsonIgnore, NotMapped]
        public virtual ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();

        //public virtual ICollection<BookLoan> Loans { get; set; } = new List<BookLoan>();

        //public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

        //public virtual ICollection<WaitingList> WaitingList { get; set; } = new List<WaitingList>();

        public Book() { }
    }

    public enum BookStatus
    {
        Available = 0,
        Lost
    }
}
