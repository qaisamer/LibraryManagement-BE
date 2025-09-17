namespace Application.DTOs.Categories;

/// <summary>
/// DTO representing a category for read operations.
/// </summary>
/// <param name="Id">The unique identifier of the category.</param>
/// <param name="Name">The name of the category.</param>
public record CategoryDto(int Id, string Name);