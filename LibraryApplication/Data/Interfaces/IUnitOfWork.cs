using LibraryApplication.Core.Interfaces;
using LibraryApplication.Domain;

namespace LibraryApplication.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository BookRepository { get; }
        IAuthorRepository AuthorRepository { get; }

        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
