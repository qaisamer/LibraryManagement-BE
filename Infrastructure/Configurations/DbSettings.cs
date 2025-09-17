namespace Infrastructure.Configurations;

/// <summary>
/// Represents the database connection settings loaded from configuration.
/// </summary>
public class DbSettings
{
    /// <summary>
    /// Gets or sets the connection string used to connect to the database.
    /// This value is typically loaded from <c>appsettings.json</c>.
    /// </summary>
    public string ConnectionString { get; set; } = string.Empty;
}