namespace Application.DTOs.Books;

/// <summary>
/// Data Transfer Object representing a book for read operations.
/// </summary>
/// <param name="Title">The title of the book.</param>
/// <param name="Author">The author of the book.</param>
/// <param name="CategoryName">The name of the category the book belongs to.</param>
public record BookDto(int id, string Title, string Author,int CategoryId, string CategoryName);
