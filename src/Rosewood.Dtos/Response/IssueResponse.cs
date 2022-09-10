namespace Rosewood.Dtos.Response;

public class IssueResponse
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; } = null!;
    public UserResponse DiscoveredBy { get; set; } = default!;
    public ProjectResponse Project { get; set;} = default!;
    public string[] Tags { get; set; } = default!;
    public bool Active { get; set; } = true;
    public DateTime Date { get; set; } = DateTime.Now;
}
