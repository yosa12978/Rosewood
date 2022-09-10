using Rosewood.Efcore.Data;

namespace Rosewood.Efcore.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly RwContext _db;

    public ProjectRepository(RwContext db) 
    {
        _db = db;
    }
    public async Task Create(Project entity)
    {
        _db.projects.Add(entity);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(string Id)
    {
        _db.projects.Remove(await _db.projects.FirstAsync(x => x.Id == Id));
        await _db.SaveChangesAsync();
    }

    public async Task<IEnumerable<Project>> GetAll()
    {
        return await _db.projects
        .Include(x => x.CreatedBy)
        .OrderBy(x => x.Title)
        .ToListAsync();
    }

    public async Task<Project> GetById(string Id)
    {
        return await _db.projects
        .Include(x => x.CreatedBy)
        .FirstAsync(x => x.Id == Id);
    }

    public async Task<IEnumerable<Project>> SearchByTitle(string title)
    {
        return await _db.projects
        .Include(x => x.CreatedBy)
        .Where(x => x.Title.Contains(title))
        .OrderBy(x => x.Title)
        .ToListAsync();
    }

    public async Task Update(Project entity)
    {
        _db.projects.Update(entity);
        await _db.SaveChangesAsync();
    }

    public bool IsExists(string Id) 
    {
        return _db.projects.Any(x => x.Id == Id);
    }
}
