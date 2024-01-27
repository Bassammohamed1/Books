using Books.Models;
using Books.Repository.Interfaces;

namespace Books.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Books = new Repository<Book>(_context);
            Authors = new Repository<Author>(_context);
        }

        public IRepository<Book> Books { get; private set; }

        public IRepository<Author> Authors { get; private set; }

        public void Commit()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
