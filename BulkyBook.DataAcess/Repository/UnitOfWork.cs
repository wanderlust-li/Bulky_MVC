using BulkyBook.DataAcess.Data;
using BulkyBook.DataAcess.Repository.IRepository;

namespace BulkyBook.DataAcess.Repository;

public class UnitOfWork : IUnitOfWork
{
    private ApplicationDbContext _db;
    public ICategoryRepository Category { get; private set; }
    public UnitOfWork(ApplicationDbContext db) 
    {
        _db = db;
        Category = new CategoryRepository(_db);
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}