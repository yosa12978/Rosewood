using Rosewood.Efcore.Data;

namespace Rosewood.Efcore.Repositories;

public class UserRepository : IUserRepository
{
    private readonly RwContext _db;

    public UserRepository(RwContext db) 
    {
        _db = db;
    }
    public async Task Create(User entity)
    {
        _db.users.Add(entity);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(string Id)
    {
        _db.users.Remove(await _db.users.FirstAsync(x => x.Id == Id));
        await _db.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _db.users.OrderByDescending(x => x.RegDate).ToListAsync();
    }

    public async Task<User> GetById(string Id)
    {
        return await _db.users.FirstAsync(x => x.Id == Id);
    }

    public async Task<IEnumerable<User>> SearchByFullname(string fullname)
    {
        return await _db.users
        .Where(x => (x.FirstName+" "+x.LastName).Contains(fullname))
        .ToListAsync();
    }

    public async Task Update(User entity)
    {
        _db.users.Update(entity);
        await _db.SaveChangesAsync();
    }

    public bool IsExists(string Id) 
    {
        return _db.users.Any(x => x.Id == Id);
    }

    public bool IsEmailTaken(string email)
    {
        return _db.users.Any(x => x.Email == email);
    }

    public bool IsUserExist(string email, string password) // password must be already hashed with smth
    {
        return _db.users.Any(x => x.Email == email && x.Password == password);
    }
}
