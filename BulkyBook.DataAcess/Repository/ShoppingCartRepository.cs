using System.Linq.Expressions;
using BulkyBook.DataAcess.Data;
using BulkyBook.DataAcess.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.DataAcess.Repository;

public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
{
    private ApplicationDbContext _db;

    public ShoppingCartRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    
    public void Update(ShoppingCart obj)
    {
        _db.ShoppingCarts.Update(obj);
    }
}