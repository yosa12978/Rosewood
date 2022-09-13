using Rosewood.Efcore.Data;

namespace Rosewood.Efcore.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly RwContext _db;
    public CommentRepository(RwContext db)
    {
        _db = db;
    }

    public async Task Create(Comment entity)
    {
        _db.comments.Add(entity);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(string Id)
    {
        var comment = await _db.comments.FirstAsync(x => x.Id == Id);
        _db.comments.Remove(comment);
        await _db.SaveChangesAsync();
    }

    public async Task<IEnumerable<Comment>> GetAll()
    {
        return await _db.comments
        .OrderBy(x => x.Date)
        .ToListAsync();
    }

    public async Task<Comment> GetById(string Id)
    {
        return await _db.comments.FirstAsync(x => x.Id == Id);
    }

    public async Task<IEnumerable<Comment>> GetCommentsByIssueId(string Id)
    {
        return await _db.comments
        .Include(x => x.Issue)
        .Where(x => x.Issue.Id == Id)
        .ToListAsync();
    }

    public bool IsExists(string Id)
    {
        return _db.comments.Any(x => x.Id == Id);
    }

    public async Task Update(Comment entity)
    {
        _db.comments.Update(entity);
        await _db.SaveChangesAsync();
    }
}
