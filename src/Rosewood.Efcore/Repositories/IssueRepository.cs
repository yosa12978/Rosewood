using Rosewood.Efcore.Data;

namespace Rosewood.Efcore.Repositories;

public class IssueRepository : IIssueRepository
{
    private readonly RwContext _db;

    public IssueRepository(RwContext db) 
    {
        _db = db;
    }

    public async Task Create(Issue entity)
    {
        _db.issues.Add(entity);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(string Id)
    {
        _db.issues.Remove(await _db.issues.FirstAsync(x => x.Id == Id));
        await _db.SaveChangesAsync();
    }

    public async Task<IEnumerable<Issue>> GetAll()
    {
        return await _db.issues
        .OrderByDescending(x => x.Date)
        .ToListAsync();
    }

    public async Task<Issue> GetById(string Id)
    {
        return await _db.issues
        .FirstAsync(x => x.Id == Id);
    }

    public async Task<IEnumerable<Issue>> SearchByName(string name)
    {
        return await _db.issues
        .Where(x => x.Name.Contains(name))
        .OrderByDescending(x => x.Date)
        .ToListAsync();
    }

    public async Task Update(Issue entity)
    {
        _db.issues.Update(entity);
        await _db.SaveChangesAsync();
    }

    public bool IsExists(string Id) 
    {
        return _db.issues.Any(x => x.Id == Id);
    }
}
