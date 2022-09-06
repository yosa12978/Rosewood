using Rosewood.Domain.Entities;
namespace Rosewood.Domain.Repositories;

public interface IProjectRepository : IBaseRepository<Project>
{
    Task<IEnumerable<Project>> SearchByTitle(string title);
}
