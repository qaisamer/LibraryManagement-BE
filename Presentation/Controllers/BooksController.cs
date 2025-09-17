using Application.DTOs.Books;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")] 
[ApiController]
public class BooksController(BookService bookService) : ControllerBase
{
    private readonly BookService _bookService = bookService;

    /// <summary>
    /// Gets all books with their categories.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetAll()
    {
        var books = await _bookService.GetAllBooksAsync();
        return Ok(books);
    }

    /// <summary>
    /// Gets a single book by ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<BookDto>> GetById(int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);
        return Ok(book);
    }

    /// <summary>
    /// Adds a new book.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult> Add([FromBody] AddBookDto dto)
    {
        await _bookService.AddBookAsync(dto);
        return Ok();
    }

    /// <summary>
    /// Updates an existing book.
    /// </summary>
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateBookDto dto)
    {
        await _bookService.UpdateBookAsync(dto);
        return NoContent();
    }

    /// <summary>
    /// Deletes a book by ID.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _bookService.DeleteBookAsync(id);
        return NoContent();
    }
}
