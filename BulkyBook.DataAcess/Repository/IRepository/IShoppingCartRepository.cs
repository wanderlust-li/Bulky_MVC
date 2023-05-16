using BulkyBook.Models;

namespace BulkyBook.DataAcess.Repository.IRepository;

public interface IShoppingCartRepository : IRepository<ShoppingCart>
{
    void Update(ShoppingCart obj);
}