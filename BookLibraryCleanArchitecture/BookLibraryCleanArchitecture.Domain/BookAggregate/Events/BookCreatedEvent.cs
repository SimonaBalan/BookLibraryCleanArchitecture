using BookLibraryCleanArchitecture.Domain.Common.Interfaces;


namespace BookLibraryCleanArchitecture.Domain.BookAggregate.Events
{
    public record BookCreatedEvent(Book Book) : IDomainEvent
    {
    }
}
