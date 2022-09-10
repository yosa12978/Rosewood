using System.Security.Claims;
using Rosewood.Services.Interfaces;
using Rosewood.Services.Exceptions;

namespace Rosewood.Services.Impls;

public class UserService : IUserService
{
    private readonly IUserRepository _repo;
    private readonly IMapper _mapper;
    private readonly IPasswordService _passwordService;
    public UserService(IUserRepository repo, IMapper mapper, IPasswordService passwordService) 
    {
        _repo = repo;
        _mapper = mapper;
        _passwordService = passwordService;
    }

    public async Task<IEnumerable<UserResponse>> GetAllUsers()
    {
        IEnumerable<User> user = await _repo.GetAll();
        return user.Select(x => _mapper.Map<UserResponse>(x));
    }

    public async Task<User> GetUserByEmail(string email) 
    {
        return await _repo.GetByEmail(email);
    }

    public async Task<ClaimsPrincipal?> LogIn(LoginRequest dto)
    {
        User usr = await _repo.GetByEmail(dto.Email);
        if (usr == null)
            throw new NotFoundException("user not found");
        List<Claim> claims = new List<Claim> 
        {
            new Claim(ClaimTypes.Email, usr.Email), 
            new Claim(ClaimTypes.Role, usr.Role)
        };
        ClaimsIdentity identity = new ClaimsIdentity(claims, "Login");
        ClaimsPrincipal principal = new ClaimsPrincipal(identity);
        return principal;
    }

    public async Task SignIn(UserCreateRequest dto)
    {
        if (_repo.IsEmailTaken(dto.Email))
            throw new BadRequestException("email is already in use");
        string pwd = _passwordService.HashPassword(dto.Password);
        User user = new User
        {
            Id = Guid.NewGuid().ToString(),
            Email = dto.Email,
            Password = dto.Password,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            RegDate = DateTime.Now,
            Role = "USER",
        };
        await _repo.Create(user);
    }

    public async Task DeleteUser(string Id, CurrentSession usr) 
    {
        User curr = await _repo.GetById(Id);
        if (!(curr.Email != usr.Email && usr.Role != "ADMIN") || curr == null )
            throw new BadRequestException("you can't delete this user");
        await _repo.Delete(Id);
    }
}
