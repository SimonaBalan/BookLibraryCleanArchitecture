using BookLibraryCleanArchitecture.Domain.BookAggregate.Events;
using MediatR;
using Microsoft.Extensions.Logging;


namespace BookLibraryCleanArchitecture.Application.DomainEventHandlers
{
    public class BookCreatedEventHandler : INotificationHandler<BookCreatedEvent>
    {
        private readonly ILogger<BookCreatedEventHandler> _logger;

        public BookCreatedEventHandler(ILogger<BookCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(BookCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Book created: {notification.Book.Title}, DomainEvent: {notification.GetType().Name}");
            return Task.CompletedTask;
        }
    }
}
