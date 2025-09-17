namespace Domain.Entities;

/// <summary>
/// Represents a book in the system.
/// </summary>
/// <remarks>
/// Inherits from <see cref="Entity{T}"/> with <see cref="int"/> as the type for the primary key.
/// </remarks>
public class Book : Entity<int>
{
    /// <summary>
    /// Gets or sets the title of the book.
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// Gets or sets the author of the book. Can be null.
    /// </summary>
    public string? Author { get; set; }

    /// <summary>
    /// Gets or sets the foreign key ID of the category this book belongs to.
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="Category"/> entity associated with this book.
    /// </summary>
    public Category? Category { get; set; }
}
