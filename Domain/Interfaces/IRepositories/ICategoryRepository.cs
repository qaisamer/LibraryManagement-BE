using Domain.Entities;

namespace Domain.Interfaces.IRepositories;

/// <summary>
/// Defines data access operations for <see cref="Category"/> entities.
/// </summary>
public interface ICategoryRepository
{
    /// <summary>
    /// Retrieves a <see cref="Category"/> by its unique identifier.
    /// </summary>
    /// <param name="id">The ID of the category to retrieve.</param>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains the <see cref="Category"/> if found; otherwise, null.
    /// </returns>
    Task<Category?> GetByIdAsync(int id);

    /// <summary>
    /// Retrieves all <see cref="Category"/> entities from the data store.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, containing a collection of <see cref="Category"/> entities.</returns>
    Task<IEnumerable<Category>> GetAllAsync();

    /// <summary>
    /// Adds a new <see cref="Category"/> to the data store.
    /// </summary>
    /// <param name="category">The <see cref="Category"/> entity to add.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task AddAsync(Category category);

    /// <summary>
    /// Updates an existing <see cref="Category"/> in the data store.
    /// </summary>
    /// <param name="category">The <see cref="Category"/> entity with updated values.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task UpdateAsync(Category category);

    /// <summary>
    /// Deletes a <see cref="Category"/> from the data store.
    /// </summary>
    /// <param name="category">The <see cref="Category"/> entity to delete.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task DeleteAsync(Category category);
}
