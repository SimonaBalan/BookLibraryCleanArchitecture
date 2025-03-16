using BookLibraryCleanArchitecture.Domain.BookAggregate.Entities;
using BookLibraryCleanArchitecture.Domain.BookAggregate;
using BookLibraryCleanArchitecture.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;
using BookLibraryCleanArcitecture.Server.Entities.Configuration;
using BookLibraryCleanArchitecture.Infrastructure.Persistence.Configuration;
using BookLibraryCleanArchitecture.Server.Entities.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BookLibraryCleanArchitecture.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<AuthorBook> BookAuthors { get; set; }

        public DbSet<BookLoan> Loans { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<WaitingList> WaitingList { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Author>().ToTable("Authors");
            modelBuilder.Entity<BookLoan>().ToTable("Loans");
            modelBuilder.Entity<Reservation>().ToTable("Reservations");
            modelBuilder.Entity<WaitingList>().ToTable("WaitingList");

            modelBuilder.Entity<AuthorBook>().HasKey(a => new { a.AuthorId, a.BookId });
            modelBuilder.Entity<Book>().HasMany(x => x.Authors)
                .WithMany(x => x.Books)
                .UsingEntity<AuthorBook>();

            modelBuilder.Entity<Book>()
                .HasMany(b => b.Loans);

            modelBuilder.Entity<Book>()
                .HasMany(b => b.Reservations);

            modelBuilder.Entity<Book>()
                .HasMany(b => b.WaitingList);

            modelBuilder.Entity<Book>()
                .Property(p => p.Version)
                .IsRowVersion()
                .IsRequired(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(a => a.Loans);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(a => a.Reservations);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(a => a.WaitingList);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new BookAuthorConfiguration());
        }
    }
}
