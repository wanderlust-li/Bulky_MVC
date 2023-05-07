using System.Linq.Expressions;
using BulkyBook.DataAcess.Data;
using BulkyBook.DataAcess.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.DataAcess.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private ApplicationDbContext _db;

    public CategoryRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    
    public void Update(Category obj)
    {
        _db.Categories.Update(obj);
    }
}