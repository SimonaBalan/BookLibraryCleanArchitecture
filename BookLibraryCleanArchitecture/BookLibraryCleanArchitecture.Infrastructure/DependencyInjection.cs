using BookLibraryCleanArchitecture.Domain.UserAggregate;
using BookLibraryCleanArchitecture.Infrastructure.Persistence;
using BookLibraryCleanArchitecture.Infrastructure.Persistence.Repository;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BookLibraryCleanArchitecture.Infrastructure.Persistence.Interceptors;
using BookLibraryCleanArchitecture.Infrastructure.Services;
using BookLibraryCleanArchitecture.Domain.Contracts.Services;
using BookLibraryCleanArchitecture.Domain.Contracts.Persistence;

namespace BookLibraryCleanArchitecture.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddScoped<PublishDomainEventInterceptor>();
            services.AddScoped<AuditableInterceptor>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();

            //services.AddScoped<IUserRespository, UserRepository>();
            services.AddScoped<IReaderRepository, ReaderRepository>();
            services.AddScoped<IWriterRepository, WriterRepository>();
            return services;
        }

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<ApplicationDbContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("LibraryConnection"), b => b.MigrationsAssembly("BookLibraryCleanArchitecture.Infrastructure")));

        public static IdentityBuilder AddPersistence(this IdentityBuilder identityBuilder)
        {
            identityBuilder
             .AddEntityFrameworkStores<ApplicationDbContext>();

            return identityBuilder;
        }
    }
}
