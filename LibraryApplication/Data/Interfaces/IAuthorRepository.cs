using LibraryApplication.Domain;

namespace LibraryApplication.Core.Interfaces
{
    public interface IAuthorRepository
    {
        Task<Author> GetByIdAsync(int id);
        Task AddAsync(Author author);
        Task DeleteAsync(Author author);
    }
}
