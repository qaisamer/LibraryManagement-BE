using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

/// <summary>
/// Represents the Entity Framework Core database context for the application.
/// </summary>
/// <remarks>
/// Provides <see cref="DbSet{T}"/> properties for accessing <see cref="Book"/> and <see cref="Category"/> entities.
/// </remarks>
/// <param name="contextOptions">The options to configure the DbContext, such as connection string and database provider.</param>
/// <remarks>
/// Initializes a new instance of the <see cref="AppDbContext"/> class with the specified options.
/// </remarks>
/// <param name="contextOptions">The options to configure the DbContext.</param>
public class AppDbContext(DbContextOptions<AppDbContext> contextOptions) : DbContext(contextOptions)
{

    /// <summary>
    /// Gets or sets the collection of <see cref="Book"/> entities in the database.
    /// </summary>
    public DbSet<Book> Books { get; set; }

    /// <summary>
    /// Gets or sets the collection of <see cref="Category"/> entities in the database.
    /// </summary>
    public DbSet<Category> Categories { get; set; }
}
