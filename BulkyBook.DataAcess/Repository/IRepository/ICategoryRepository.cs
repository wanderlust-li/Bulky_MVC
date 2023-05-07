using BulkyBook.Models;

namespace BulkyBook.DataAcess.Repository.IRepository;

public interface ICategoryRepository : IRepository<Category>
{
    void Update(Category obj);
}