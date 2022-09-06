using Rosewood.Domain.Entities;

namespace Rosewood.Domain.Repositories;

public interface IIssueRepository : IBaseRepository<Issue>
{
    Task<IEnumerable<Issue>> SearchByName(string name);
}
