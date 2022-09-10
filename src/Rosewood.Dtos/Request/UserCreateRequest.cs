namespace Rosewood.Dtos.Request;

public class UserCreateRequest
{
    public string Email {get;set;} = default!;
    public string Password {get;set;} = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
}
