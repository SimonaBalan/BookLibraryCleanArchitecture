using BookLibraryCleanArchitecture.Domain.Contracts.Services;
using System.Security.Claims;

namespace BookLibraryCleanArchitecture.Server.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid? UserId
        {
            get
            {
                var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId == null)
                    return null;
                return new Guid(userId);
            }
        }

    }
}
