namespace Rosewood.Dtos.Response;

public class ProjectResponse
{
    public string Id { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public UserResponse CreatedBy { get; set; } = default!;
}
