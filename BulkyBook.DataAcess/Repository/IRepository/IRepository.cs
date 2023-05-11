using System.Linq.Expressions;

namespace BulkyBook.DataAcess.Repository.IRepository;

public interface IRepository<T> where T : class
{
    // T - Category
    IEnumerable<T> GetAll(string? includePropetries = null);
    T Get(Expression<Func<T, bool>> filter, string? includePropetries = null);
    void Add(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entity);

}