

using BookLibraryCleanArchitecture.Domain.Contracts.Services;

namespace BookLibraryCleanArchitecture.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
