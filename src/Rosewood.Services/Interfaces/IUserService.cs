using System.Security.Claims;

namespace Rosewood.Services.Interfaces;

public interface IUserService
{
    Task<ClaimsPrincipal?> LogIn(LoginRequest dto);
    Task SignIn(UserCreateRequest dto);
    Task<IEnumerable<UserResponse>> GetAllUsers();
    Task<User> GetUserByEmail(string email);
    Task DeleteUser(string Id, CurrentSession usr);
}
