using LibraryApplication.Domain;

namespace LibraryApplication.Core.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> GetByIdAsync(int id);
        Task<IEnumerable<Book>> GetAllAsync(int pageSize, int pageNumber);
        Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(int authorId, int pageSize, int pageNumber);
        Task<Book> AddAsync(Book book);
        Task<Book> UpdateAsync(Book book);
        Task DeleteAsync(int bookId);
        int GetTotalBooksByAuthorId(int authorId);
        int GetTotalBooks();
    }
}
