using LibraryApplication.Core.Interfaces;
using LibraryApplication.Data;
using LibraryApplication.Domain;
using Microsoft.EntityFrameworkCore;

namespace LibraryApplication.Services
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _dbContext;

        public BookRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _dbContext.Books.FindAsync(id);
        }

        public async Task<IEnumerable<Book>> GetAllAsync(int itemsToSkip, int itemsToTake)
        {
            var books = await _dbContext.Books
                .OrderBy(b => b.Id)
                .Skip(itemsToSkip)
                .Take(itemsToTake)
                .ToListAsync();
            return books;
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(int authorId, int itemsToSkip, int itemsToTake)
        {
            var books = await _dbContext.Books
                .Where(b => b.AuthorId == authorId)
                .OrderBy(b => b.Id)
                .Skip(itemsToSkip)
                .Take(itemsToTake)
                .ToListAsync();

            return books;
        }

        public async Task<Book> AddAsync(Book book)
        {
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            _dbContext.Entry(book).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return book;
        }

        public async Task DeleteAsync(int bookId)
        {
            var book = await _dbContext.Books.FindAsync(bookId);
            if (book != null)
            {
                _dbContext.Books.Remove(book);
                await _dbContext.SaveChangesAsync();
            }
        }

        public int GetTotalBooksByAuthorId(int authorId)
        {
            // Use LINQ to query the database and count the books by authorId
            var totalBooks = _dbContext.Books.Count(b => b.AuthorId == authorId);

            return totalBooks;
        }

        public int GetTotalBooks()
        {
            var totalBooks = _dbContext.Books.Count();
            return totalBooks;
        }
    }
}
