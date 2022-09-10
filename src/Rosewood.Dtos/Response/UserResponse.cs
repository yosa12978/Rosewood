namespace Rosewood.Dtos.Response;

public class UserResponse
{
    public string Id { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateTime RegDate { get; set; } = default!;
}
