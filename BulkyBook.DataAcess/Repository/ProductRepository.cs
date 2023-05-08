using System.Linq.Expressions;
using BulkyBook.DataAcess.Data;
using BulkyBook.DataAcess.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.DataAcess.Repository;

public class ProductRepository: Repository<Product>, IProductRepository
{
    private ApplicationDbContext _db;

    public ProductRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    
    public void Update(Product obj)
    {
        _db.Products.Update(obj);
    }
}