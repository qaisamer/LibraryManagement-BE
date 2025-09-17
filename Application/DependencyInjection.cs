using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

/// <summary>
/// Provides extension methods for registering services related to the Application layer.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds Application layer services to the <see cref="IServiceCollection"/>.
    /// This typically includes application services, use cases, and interfaces from the Application layer.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to register services to.</param>
    /// <returns>The same <see cref="IServiceCollection"/> instance with registered Application services.</returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<BookService>();
        services.AddScoped<CategoryService>();

        return services;
    }
}