using System.Linq.Expressions;

namespace BulkyBook.DataAcess.Repository.IRepository;

public interface IRepository<T> where T : class
{
    // T - Category
    IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includePropetries = null);
    T Get(Expression<Func<T, bool>> filter, string? includePropetries = null, bool tracked = false);
    void Add(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entity);

}