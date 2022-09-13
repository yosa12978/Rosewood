using Rosewood.Domain.Entities;

namespace Rosewood.Domain.Repositories;

public interface ICommentRepository : IBaseRepository<Comment>
{
    Task<IEnumerable<Comment>> GetCommentsByIssueId(string Id);
}
