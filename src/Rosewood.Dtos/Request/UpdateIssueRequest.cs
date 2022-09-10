namespace Rosewood.Dtos.Request;

public class UpdateIssueRequest 
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string[] Tags { get; set; } = default!;
}