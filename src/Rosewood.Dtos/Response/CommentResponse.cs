namespace Rosewood.Dtos.Response;

public class CommentResponse
{
    public string Text { get; set; } = default!;
    public UserResponse Author { get; set; } = default!;
    public bool IsChanged { get; set; } = default!; 
}
