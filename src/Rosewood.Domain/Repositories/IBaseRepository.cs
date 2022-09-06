using Rosewood.Domain.Entities;
namespace Rosewood.Domain.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T> GetById(string Id);
    Task<IEnumerable<T>> GetAll();
    Task Create(T entity);
    Task Update(T entity);
    Task Delete(string Id);
    bool IsExists(string Id);
}
