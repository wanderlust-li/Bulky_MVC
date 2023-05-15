using BulkyBook.Models;

namespace BulkyBook.DataAcess.Repository.IRepository;

public interface ICompanyRepository : IRepository<Company>
{
    void Update(Company obj);
}