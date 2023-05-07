namespace BulkyBook.DataAcess.Repository.IRepository;

public interface IUnitOfWork
{
    ICategoryRepository Category { get; }
    void Save();
}