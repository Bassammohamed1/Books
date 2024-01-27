using System.Linq.Expressions;

namespace Books.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        T Get(Expression<Func<T, bool>> data);
        void Add(T data);
        void Update(T data);
        void Delete(T data);

    }
}
