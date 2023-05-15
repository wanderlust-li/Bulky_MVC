using System.Linq.Expressions;
using BulkyBook.DataAcess.Data;
using BulkyBook.DataAcess.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.DataAcess.Repository;

public class CompanyRepository : Repository<Company>, ICompanyRepository
{
    private ApplicationDbContext _db;

    public CompanyRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    
    public void Update(Company obj)
    {
        _db.Companies.Update(obj);
    }
}