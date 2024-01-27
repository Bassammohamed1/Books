using Books.Models;
using Books.Repository.Interfaces;
using System.Linq.Expressions;

namespace Books.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public T Get(Expression<Func<T, bool>> data)
        {
            return _context.Set<T>().SingleOrDefault(data);
        }
        public void Add(T data)
        {
            _context.Set<T>().Add(data);
        }
        public void Update(T data)
        {
            _context.Set<T>().Update(data);
        }
        public void Delete(T data)
        {
            _context.Set<T>().Remove(data);
        }
    }
}
