namespace Rosewood.Dtos.Request;

public class CreateIssueRequest
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string ProjectID { get; set; } = default!;
    public string[] Tags { get; set; } = default!;
}
