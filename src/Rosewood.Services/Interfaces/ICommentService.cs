namespace Rosewood.Services.Interfaces;

public interface ICommentService
{
    Task<CommentResponse> GetCommentById(string Id);
    Task<IEnumerable<CommentResponse>> GetCommentsByIssueId(string Id);
    Task CreateComment(string Id, CreateCommentRequest dto, CurrentSession usr);
    Task DeleteComment(string Id, CurrentSession usr);
    Task UpdateComment(string Id, UpdateCommentRequest dto, CurrentSession usr);
}
