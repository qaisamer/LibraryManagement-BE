using Application.Interfaces;
using Domain.Interfaces.IRepositories;
using Infrastructure.Configurations;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

/// <summary>
/// Provides extension methods for configuring dependency injection for the infrastructure layer.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Registers the Infrastructure layer services into the dependency injection container.
    /// This includes the <see cref="AppDbContext"/> for EF Core and repository implementations.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to which the services will be added.</param>
    /// <param name="configuration">The <see cref="IConfiguration"/> instance used to retrieve configuration values, such as the connection string.</param>
    /// <returns>The same <see cref="IServiceCollection"/> instance with the registered Infrastructure services.</returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>((provider, options) => options.UseSqlServer(configuration.GetConnectionString("LibraryManagementConnection")));
        services.Configure<DbSettings>(options => { options.ConnectionString = configuration.GetConnectionString("LibraryManagementConnection")!; });
        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddLogging();
        return services;
    }
}