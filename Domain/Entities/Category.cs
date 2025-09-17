namespace Domain.Entities;

/// <summary>
/// Represents a category of books in the system.
/// </summary>
/// <remarks>
/// Inherits from <see cref="Entity{T}"/> with <see cref="int"/> as the type for the primary key.
/// </remarks>
public class Category : Entity<int>
{
    /// <summary>
    /// Gets or sets the name of the category.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the collection of <see cref="Book"/> entities associated with this category.
    /// </summary>
    public ICollection<Book> Books { get; set; } = [];
}
