

namespace BookLibraryCleanArchitecture.Domain.Contracts.Services
{
    public interface ILoggedInUserService
    {
        Guid? UserId { get; }
    }
}
