using Rosewood.Domain.Entities;

namespace Rosewood.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<IEnumerable<User>> SearchByFullname(string fullname);
    Task<User> GetByEmail(string email);
    bool IsEmailTaken(string email);
    bool IsUserExist(string email, string password);
}
