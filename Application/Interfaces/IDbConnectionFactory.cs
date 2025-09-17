using System.Data;

namespace Application.Interfaces;

/// <summary>
/// Factory for creating and opening database connections.
/// </summary>
public interface IDbConnectionFactory
{
    /// <summary>
    /// Creates and opens a new <see cref="IDbConnection"/>.
    /// </summary>
    /// <returns>An open <see cref="IDbConnection"/>.</returns>
    Task<IDbConnection> CreateOpenConnection();
}