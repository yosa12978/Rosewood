namespace Rosewood.Services.Interfaces;

public interface IUserService
{
    Task LogIn(LoginRequest dto);
    Task SignIn(UserCreateRequest dto);
    Task<IEnumerable<UserResponse>> GetAllUsers();
}
