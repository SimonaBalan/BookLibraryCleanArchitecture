using BookLibraryCleanArchitecture.Domain.BookAggregate.Entities;
using Microsoft.AspNetCore.Identity;

namespace BookLibraryCleanArchitecture.Domain.UserAggregate
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public UserStatus Status { get; set; }

        public string? Address { get; set; }

        public ApplicationUser() { } // for ef core

        private ApplicationUser(string firstName, string lastName, string userName, string email, 
            DateTime birthDate, UserStatus status, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            BirthDate = birthDate;
            Status = status;
            Address = address;
        }

        public virtual IReadOnlyList<BookLoan> Loans { get; set; }

        public virtual IReadOnlyList<Reservation> Reservations { get; set; }

        public virtual IReadOnlyList<WaitingList> WaitingList { get; set; }

        public static ApplicationUser Create(string firstName, string lastName, string userName, 
            string email, DateTime birthDate, UserStatus status, string address) 
            => new(firstName, lastName, userName, email, birthDate, status, address);
    }

    public enum UserStatus
    {
        Active = 0,
        Blocked
    }
}
