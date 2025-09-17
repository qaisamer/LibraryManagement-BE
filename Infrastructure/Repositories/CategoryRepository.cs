using Domain.Entities;
using Domain.Interfaces.IRepositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

/// <summary>
/// Provides a concrete implementation of <see cref="ICategoryRepository"/> using Entity Framework Core.
/// Handles CRUD operations for <see cref="Category"/> entities.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="CategoryRepository"/> class.
/// </remarks>
/// <param name="context">The <see cref="AppDbContext"/> used for database operations.</param>
public class CategoryRepository(AppDbContext context) : ICategoryRepository
{
    private readonly AppDbContext _context = context;

    /// <summary>
    /// Adds a new <see cref="Category"/> entity to the database.
    /// </summary>
    /// <param name="category">The <see cref="Category"/> entity to add.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task AddAsync(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Deletes an existing <see cref="Category"/> entity from the database.
    /// </summary>
    /// <param name="category">The <see cref="Category"/> entity to delete.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task DeleteAsync(Category category)
    {
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Retrieves all <see cref="Category"/> entities from the database.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, containing a collection of <see cref="Category"/> entities.</returns>
    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    /// <summary>
    /// Retrieves a <see cref="Category"/> entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the <see cref="Category"/>.</param>
    /// <returns>A task representing the asynchronous operation, containing the <see cref="Category"/> if found; otherwise, null.</returns>
    public async Task<Category?> GetByIdAsync(int id)
    {
        return await _context.Categories.FindAsync(id);
    }

    /// <summary>
    /// Updates an existing <see cref="Category"/> entity in the database.
    /// </summary>
    /// <param name="category">The <see cref="Category"/> entity with updated values.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task UpdateAsync(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
    }
}
