namespace Presentation;

/// <summary>
/// Provides extension methods for configuring dependency injection for the Presentation API layer.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Registers Presentation API-specific services to the <see cref="IServiceCollection"/>.
    /// This method is a placeholder for adding dependencies related to the Presentation API layer.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to which Presentation API services will be added.</param>
    /// <returns>The same <see cref="IServiceCollection"/> instance with the registered Presentation API services.</returns>
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        //services.AddScoped<ICurrentUser<Ulid, string>, CurrentUser>();
        //services.AddValidatorsFromAssemblyContaining<GetTenantByIdQueryValidator>();
        //services.AddValidatorsFromAssemblyContaining<GetAllTenantsQueryValidator>();
        //services.AddValidatorsFromAssemblyContaining<CreateTenantCommandValidator>();
        //services.AddValidatorsFromAssemblyContaining<UpdateTenantCommandValidator>();
        //services.AddValidatorsFromAssemblyContaining<UpdateTenantIdValidator>();
        //services.AddHttpContextAccessor();
        return services;
    }
}