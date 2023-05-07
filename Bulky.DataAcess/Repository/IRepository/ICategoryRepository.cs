using Bulky.Models;

namespace Bulky.DataAcess.Repository.IRepository;

public interface ICategoryRepository : IRepository<Category>
{
    void Update(Category obj);
    void Save();
}