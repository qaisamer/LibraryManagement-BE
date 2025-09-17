namespace Application.DTOs.Books;

/// <summary>
/// Data Transfer Object used to update an existing book.
/// </summary>
/// <param name="Id">The unique identifier of the book to update.</param>
/// <param name="Title">The new title of the book.</param>
/// <param name="Author">The new author of the book. Can be null.</param>
/// <param name="CategoryId">The ID of the category the book belongs to.</param>
public record UpdateBookDto(int Id, string Title, string? Author, int CategoryId);
