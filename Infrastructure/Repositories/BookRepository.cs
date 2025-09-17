using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.IRepositories;
using Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Infrastructure.Repositories;

/// <summary>
/// Provides a concrete implementation of <see cref="IBookRepository"/> using Entity Framework Core.
/// Handles CRUD operations for <see cref="Book"/> entities.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="BookRepository"/> class.
/// </remarks>
/// <param name="context">The <see cref="AppDbContext"/> used for database operations.</param>
public class BookRepository(AppDbContext context, IDbConnectionFactory connectionFactory) : IBookRepository
{
    private readonly AppDbContext _context = context;
    private readonly IDbConnectionFactory _connectionFactory = connectionFactory;

    /// <summary>
    /// Adds a new <see cref="Book"/> entity to the database.
    /// </summary>
    /// <param name="book">The <see cref="Book"/> entity to add.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task AddAsync(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Deletes an existing <see cref="Book"/> entity from the database.
    /// </summary>
    /// <param name="book">The <see cref="Book"/> entity to delete.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task DeleteAsync(Book book)
    {
        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Retrieves all <see cref="Book"/> entities from the database.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, containing a collection of <see cref="Book"/> entities.</returns>
    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        var books = new List<Book>();

        using IDbConnection conn = await _connectionFactory.CreateOpenConnection();
        using SqlCommand cmd = (SqlCommand)conn.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetAllBooksWithCategory";

        using SqlDataReader reader = await cmd.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            books.Add(new Book
            {
                Id = reader.GetInt32(reader.GetOrdinal("BookId")),
                Title = reader.GetString(reader.GetOrdinal("Title")),
                Author = reader.IsDBNull(reader.GetOrdinal("Author"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("Author")),
                Category = new Category
                {
                    Id = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                    Name = reader.GetString(reader.GetOrdinal("CategoryName"))
                }
            });
        }

        return books;
    }
    /// <summary>
    /// Retrieves a <see cref="Book"/> entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the <see cref="Book"/>.</param>
    /// <returns>A task representing the asynchronous operation, containing the <see cref="Book"/> if found; otherwise, null.</returns>
    public async Task<Book?> GetByIdAsync(int id) =>
         await _context.Books.Include(c => c.Category).FirstOrDefaultAsync(i => i.Id == id);

    /// <summary>
    /// Updates an existing <see cref="Book"/> entity in the database.
    /// </summary>
    /// <param name="book">The <see cref="Book"/> entity with updated values.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task UpdateAsync(Book book)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
    }
}
