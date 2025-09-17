using Domain.Entities;

namespace Domain.Interfaces.IRepositories;

/// <summary>
/// Defines data access operations for <see cref="Book"/> entities.
/// </summary>
public interface IBookRepository
{
    /// <summary>
    /// Retrieves a <see cref="Book"/> by its unique identifier.
    /// </summary>
    /// <param name="id">The ID of the book to retrieve.</param>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains the <see cref="Book"/> if found; otherwise, null.
    /// </returns>
    Task<Book?> GetByIdAsync(int id);

    /// <summary>
    /// Retrieves all <see cref="Book"/> entities from the data store.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, containing a collection of <see cref="Book"/> entities.</returns>
    Task<IEnumerable<Book>> GetAllAsync();

    /// <summary>
    /// Adds a new <see cref="Book"/> to the data store.
    /// </summary>
    /// <param name="book">The <see cref="Book"/> entity to add.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task AddAsync(Book book);

    /// <summary>
    /// Updates an existing <see cref="Book"/> in the data store.
    /// </summary>
    /// <param name="book">The <see cref="Book"/> entity with updated values.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task UpdateAsync(Book book);

    /// <summary>
    /// Deletes a <see cref="Book"/> from the data store.
    /// </summary>
    /// <param name="book">The <see cref="Book"/> entity to delete.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task DeleteAsync(Book book);
}
