
namespace BookLibraryCleanArchitecture.Domain.Contracts.Services
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}
