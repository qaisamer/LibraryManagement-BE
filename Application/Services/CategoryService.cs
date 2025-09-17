using Application.DTOs.Books;
using Application.DTOs.Categories;
using Application.Extentions;
using Domain.Entities;
using Domain.Interfaces.IRepositories;

namespace Application.Services;

/// <summary>
/// Provides business logic operations for <see cref="Category"/> entities.
/// Uses <see cref="ICategoryRepository"/> to interact with the data store.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="CategoryService"/> class.
/// </remarks>
/// <param name="categoryRepository">The repository used for data access operations on categories.</param>
public class CategoryService(ICategoryRepository categoryRepository)
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    /// <summary>
    /// Retrieves all categories from the data store.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, containing a collection of <see cref="CategoryDto"/>.</returns>
    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();
        return categories.Select(c => new CategoryDto(c.Id, c.Name));
    }

    /// <summary>
    /// Retrieves a category by its unique identifier.
    /// </summary>
    /// <param name="id">The ID of the category.</param>
    /// <returns>
    /// A task representing the asynchronous operation, containing the <see cref="CategoryDto"/> if found; otherwise, throws a <see cref="ServiceException"/>.
    /// </returns>
    public async Task<CategoryDto> GetCategoryByIdAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id) ?? throw new ServiceException($"Category with ID {id} was not found.");
        return new CategoryDto(category.Id, category.Name);
    }

    /// <summary>
    /// Adds a new category to the data store.
    /// </summary>
    /// <param name="dto">The DTO containing the data for the new category.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task AddCategoryAsync(AddCategoryDto dto)
    {
        var category = new Category
        {
            Name = dto.Name
        };

        await _categoryRepository.AddAsync(category);
    }

    /// <summary>
    /// Updates an existing category in the data store.
    /// </summary>
    /// <param name="dto">The DTO containing updated values for the category.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    /// <exception cref="ServiceException">Thrown if the category does not exist.</exception>
    public async Task UpdateCategoryAsync(UpdateCategoryDto dto)
    {
        var category = await _categoryRepository.GetByIdAsync(dto.Id) ?? throw new ServiceException("Category not found");

        category.Name = dto.Name;

        await _categoryRepository.UpdateAsync(category);
    }

    /// <summary>
    /// Deletes a category from the data store.
    /// </summary>
    /// <param name="id">The ID of the category to delete.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    /// <exception cref="ServiceException">Thrown if the category does not exist.</exception>
    public async Task DeleteCategoryAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id) ?? throw new ServiceException($"Category with ID {id} was not found.");

        await _categoryRepository.DeleteAsync(category);
    }
}
