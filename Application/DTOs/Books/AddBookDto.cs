namespace Application.DTOs.Books;

/// <summary>
/// Data Transfer Object used to add a new book to the system.
/// </summary>
/// <param name="Title">The title of the book.</param>
/// <param name="Author">The author of the book.</param>
/// <param name="CategoryId">The ID of the existing category the book belongs to.</param>
public record AddBookDto(string Title, string Author, int CategoryId);
