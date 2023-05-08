using BulkyBook.Models;

namespace BulkyBook.DataAcess.Repository.IRepository;

public interface IProductRepository : IRepository<Product>
{
    void Update(Product obj);
}