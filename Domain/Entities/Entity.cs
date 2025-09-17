namespace Domain.Entities;

/// <summary>
/// Represents the base class for all entities in the domain layer.
/// </summary>
/// <typeparam name="T">The type of the primary key (e.g., int, Guid).</typeparam>
public abstract class Entity<T>
{
    /// <summary>
    /// Gets or sets the primary key of the entity.
    /// </summary>
    public T Id { get; set; }
}
