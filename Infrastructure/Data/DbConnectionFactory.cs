using Application.Interfaces;
using Infrastructure.Configurations;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.Common;

namespace Infrastructure.Data;

/// <summary>
/// Provides a factory for creating and opening SQL connections.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="DbConnectionFactory"/> class.
/// </remarks>
/// <param name="options">The options monitor for <see cref="DbSettings"/>.</param>
public class DbConnectionFactory(IOptionsMonitor<DbSettings> options) : IDbConnectionFactory
{
    private readonly IOptionsMonitor<DbSettings> _options = options;
    /// <summary>
    /// Creates and opens a new SQL connection using the configured connection string.
    /// </summary>
    /// <returns>An open <see cref="IDbConnection"/>.</returns>
    public async Task<IDbConnection> CreateOpenConnection()
    {
        SqlConnection conn = new(_options.CurrentValue.ConnectionString);
        await conn.OpenAsync().ConfigureAwait(false);
        return conn;
    }
}
