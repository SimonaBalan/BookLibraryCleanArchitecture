using BookLibraryCleanArchitecture.Domain.Contracts.Services;
using BookLibraryCleanArchitecture.Server.Mappings;
using BookLibraryCleanArchitecture.Server.Services;

namespace BookLibraryCleanArchitecture.Server
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddScoped<ILoggedInUserService, LoggedInUserService>();
            services.AddMappings();
            return services;
        }
    }
}
