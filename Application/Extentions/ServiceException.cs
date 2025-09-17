namespace Application.Extentions;

/// <summary>
/// Custom exception for application-level errors.
/// </summary>
/// <remarks>
/// Initializes a new instance of <see cref="ServiceException"/>.
/// </remarks>
/// <param name="message">The human-readable error message.</param>
public class ServiceException(string message) : Exception(message)
{
}