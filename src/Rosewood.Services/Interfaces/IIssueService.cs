namespace Rosewood.Services.Interfaces;

public interface IIssueService
{
    Task<IEnumerable<IssueResponse>> GetOpenIssuesOfProject(string ProjectID);
    Task<IEnumerable<IssueResponse>> GetClosedIssuesOfProject(string ProjectID);
    Task<IEnumerable<IssueResponse>> GetAllOpenIssues();
    Task<IEnumerable<IssueResponse>> GetAllClosedIssues();
    Task<IssueResponse> GetIssueById(string Id);
    Task CloseIssue(string Id);
    Task OpenIssue(string Id);
    bool IsIssueExist(string Id);
    Task UpdateIssue(string Id, UpdateIssueRequest dto, CurrentSession usr);
    Task DeleteIssue(string Id, CurrentSession usr);
    Task CreateIssue(CreateIssueRequest dto, CurrentSession usr);
}
