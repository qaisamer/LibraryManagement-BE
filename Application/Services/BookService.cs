using Application.DTOs.Books;
using Application.Extentions;
using Domain.Entities;
using Domain.Interfaces.IRepositories;

namespace Application.Services;

/// <summary>
/// Provides business logic operations for <see cref="Book"/> entities.
/// Uses <see cref="IBookRepository"/> to interact with the data store.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="BookService"/> class.
/// </remarks>
/// <param name="bookRepository">The repository used for data access operations on books.</param>
public class BookService(IBookRepository bookRepository)
{
    private readonly IBookRepository _bookRepository = bookRepository;

    /// <summary>
    /// Retrieves all books from the data store.
    /// </summary>
    /// <returns>
    /// A task representing the asynchronous operation, containing a collection of <see cref="BookDto"/> objects.
    /// </returns>
    public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
    {
        var books = await _bookRepository.GetAllAsync();
        return books.Select(b => new BookDto(b.Id, b.Title, b.Author!, b.Category!.Id, b.Category.Name));
    }

    /// <summary>
    /// Retrieves a book by its unique identifier.
    /// </summary>
    /// <param name="id">The ID of the book.</param>
    /// <returns>
    /// A task representing the asynchronous operation, containing the <see cref="BookDto"/> if found; otherwise, throws a <see cref="ServiceException"/>.
    /// </returns>
    public async Task<BookDto> GetBookByIdAsync(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id) ?? throw new ServiceException($"Book with ID {id} was not found.");
        return new BookDto(book.Id, book.Title, book.Author!,book.Category.Id, book.Category!.Name);
    }

    /// <summary>
    /// Adds a new book to the data store.
    /// </summary>
    /// <param name="dto">The DTO containing the data for the new book.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task AddBookAsync(AddBookDto dto)
    {
        var book = new Book
        {
            Title = dto.Title,
            Author = dto.Author,
            CategoryId = dto.CategoryId
        };

        await _bookRepository.AddAsync(book);
    }

    /// <summary>
    /// Updates an existing book in the data store.
    /// </summary>
    /// <param name="dto">The DTO containing updated values for the book.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    /// <exception cref="ServiceException">Thrown if the book does not exist.</exception>
    public async Task UpdateBookAsync(UpdateBookDto dto)
    {
        var book = await _bookRepository.GetByIdAsync(dto.Id) ?? throw new ServiceException("Book not found");

        book.Title = dto.Title;
        book.Author = dto.Author;
        book.CategoryId = dto.CategoryId;

        await _bookRepository.UpdateAsync(book);
    }

    /// <summary>
    /// Deletes a book from the data store.
    /// </summary>
    /// <param name="id">The ID of the book to delete.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    /// <exception cref="ServiceException">Thrown if the book does not exist.</exception>
    public async Task DeleteBookAsync(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id) ?? throw new ServiceException($"Book with ID {id} was not found.");

        await _bookRepository.DeleteAsync(book);
    }
}
