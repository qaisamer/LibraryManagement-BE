namespace Application.DTOs.Categories;

/// <summary>
/// DTO used to update an existing category.
/// </summary>
/// <param name="Id">The unique identifier of the category.</param>
/// <param name="Name">The new name of the category.</param>
public record UpdateCategoryDto(int Id, string Name);