using LibraryApplication.Core.Interfaces;
using LibraryApplication.Data;
using LibraryApplication.Domain;
using Microsoft.EntityFrameworkCore;

namespace LibraryApplication.Services
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDbContext _dbContext;

        public AuthorRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            return await _dbContext.Authors.FindAsync(id);
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _dbContext.Authors.ToListAsync();
        }

        public async Task AddAsync(Author author)
        {
            await _dbContext.Authors.AddAsync(author);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Author author)
        {
            _dbContext.Authors.Update(author);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Author author)
        {
            _dbContext.Authors.Remove(author);
            await _dbContext.SaveChangesAsync();
        }
    }
}
