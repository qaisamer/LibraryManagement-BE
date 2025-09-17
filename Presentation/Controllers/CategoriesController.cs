using Application.DTOs.Books;
using Application.DTOs.Categories;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(CategoryService categoryService) : ControllerBase
    {
        private readonly CategoryService _categoryService = categoryService;

        /// <summary>
        /// Gets all categories.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        /// <summary>
        /// Gets a single book by ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            return Ok(category);
        }

        /// <summary>
        /// Adds a new category.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] AddCategoryDto dto)
        {
            await _categoryService.AddCategoryAsync(dto);
            return Ok();
        }

        /// <summary>
        /// Updates an existing category.
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateCategoryDto dto)
        {
            await _categoryService.UpdateCategoryAsync(dto);
            return Ok();
        }

        /// <summary>
        /// Deletes a category by ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}
