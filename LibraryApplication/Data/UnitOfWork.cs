using LibraryApplication.Data.Interfaces;
using LibraryApplication.Domain;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using LibraryApplication.Core.Interfaces;
using LibraryApplication.Services;
using Microsoft.AspNetCore.SignalR;

namespace LibraryApplication.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDbContext _dbContext;
        private IAuthorRepository _authorRepository;
        private IBookRepository _bookRepository;
        private IDbContextTransaction _transaction;

        public UnitOfWork(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IAuthorRepository AuthorRepository
        {
            get
            {
                if (_authorRepository == null)
                {
                    _authorRepository = new AuthorRepository(_dbContext);
                }
                return _authorRepository;
            }
        }

        public IBookRepository BookRepository
        {
            get
            {
                if (_bookRepository == null)
                {
                    _bookRepository = new BookRepository(_dbContext);
                }
                return _bookRepository;
            }
        }

        public void BeginTransaction()
        {
            _transaction = _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction?.Commit();
            _transaction = null;
        }

        public void Rollback()
        {
            _transaction?.Rollback();
            _transaction = null;
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _dbContext.Dispose();
        }
    }
}