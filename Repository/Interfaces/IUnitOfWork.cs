using Books.Models;

namespace Books.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Book> Books { get; }
        IRepository<Author> Authors { get; }
        void Commit();
    }
}
