namespace Application.DTOs.Categories;

/// <summary>
/// DTO used to add a new category.
/// </summary>
/// <param name="Name">The name of the category.</param>
public record AddCategoryDto(string Name);