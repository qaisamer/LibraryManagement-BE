using Application.Extentions;
using System.Text.Json;

namespace Presentation.Middlewares;

/// <summary>
/// Middleware for handling exceptions and generating appropriate HTTP responses.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ExceptionHandlerMiddleware"/> class.
/// </remarks>
/// <param name="next">The next middleware in the pipeline.</param>
/// <param name="logger">The logger instance.</param>
public class ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger = logger;

    /// <summary>
    /// Invokes the middleware to handle exceptions and generate appropriate HTTP responses.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ServiceException ex)
        {
            _logger.LogWarning("ServiceException occurred: {Message}", ex.Message);
            await HandleExceptionAsync(context, ex.Message, StatusCodes.Status400BadRequest);
        }
        catch (Exception ex)
        {
            _logger.LogError("An unexpected error occurred: {Message}", ex.Message);
            await HandleExceptionAsync(context, "An unexpected error occurred.", StatusCodes.Status400BadRequest);
        }
    }
    /// <summary>
    /// Handles the exception and generates the appropriate HTTP response with just the plain text error message.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <param name="message">The exception message to include in the response.</param>
    /// <param name="statusCode">The HTTP status code to set for the response.</param>
    private static async Task HandleExceptionAsync(HttpContext context, string message, int statusCode)
    {
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";

        string result = JsonSerializer.Serialize(new { error = message });
        await context.Response.WriteAsync(result);
    }
}