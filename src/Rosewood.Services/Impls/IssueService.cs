using Rosewood.Services.Interfaces;
using Rosewood.Services.Exceptions;

namespace Rosewood.Services.Impls;

public class IssueService : IIssueService
{
    private readonly IIssueRepository _repo;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    private readonly IProjectService _projectService;
    public IssueService(IIssueRepository repo, IMapper mapper, IUserService userService, IProjectService projectService)
    {
        _repo = repo;
        _mapper = mapper;
        _userService = userService;
        _projectService = projectService;
    }

    public async Task CloseIssue(string Id)
    {
        Issue issue = await _repo.GetById(Id);
        issue.Active = false;
    }

    public async Task DeleteIssue(string Id, CurrentSession usr)
    {
        Issue issue = await _repo.GetById(Id);
        if (!(issue.DiscoveredBy.Email != usr.Email && usr.Role != "ADMIN") || issue == null)
            throw new BadRequestException("you can't delete this issue");
        await _repo.Delete(Id);
    }

    public async Task UpdateIssue(string Id, UpdateIssueRequest dto, CurrentSession usr)
    {
        Issue issue = await _repo.GetById(Id);
        if (!(issue.DiscoveredBy.Email != usr.Email && usr.Role != "ADMIN") || issue == null)
            throw new BadRequestException("you can't update this issue");
        issue = _mapper.Map<Issue>(dto);
        await _repo.Update(issue);
    }

    public async Task CreateIssue(CreateIssueRequest dto, CurrentSession usr)
    {
        Issue issue = new Issue
        {
            Id = Guid.NewGuid().ToString(),
            DiscoveredBy = await _userService.GetUserByEmail(usr.Email),
            Name = dto.Name,
            Description = dto.Description,
            Active = true,
            Project = await _projectService.GetProjectM(dto.ProjectID)
        };
        await _repo.Create(issue);
    }

    public async Task<IEnumerable<IssueResponse>> GetAllClosedIssues()
    {
        IEnumerable<Issue> issues = await _repo.GetAll();
        return issues.Where(x => !x.Active).Select(x => _mapper.Map<IssueResponse>(x));
    }

    public async Task<IEnumerable<IssueResponse>> GetAllOpenIssues()
    {
        IEnumerable<Issue> issues = await _repo.GetAll();
        return issues.Where(x => x.Active).Select(x => _mapper.Map<IssueResponse>(x));
    }

    public async Task<IEnumerable<IssueResponse>> GetClosedIssuesOfProject(string ProjectID)
    {
        IEnumerable<Issue> issues = await _repo.GetIssuesByProjectId(ProjectID);
        return issues.Where(x => !x.Active).Select(x => _mapper.Map<IssueResponse>(x));
    }

    public async Task<IssueResponse> GetIssueById(string Id)
    {
        Issue issue = await _repo.GetById(Id);
        return _mapper.Map<IssueResponse>(issue);
    }

    public async Task<IEnumerable<IssueResponse>> GetOpenIssuesOfProject(string ProjectID)
    {
        IEnumerable<Issue> issues = await _repo.GetIssuesByProjectId(ProjectID);
        return issues.Where(x => x.Active).Select(x => _mapper.Map<IssueResponse>(x));
    }

    public bool IsIssueExist(string Id)
    {
        return _repo.IsExists(Id);
    }

    public async Task OpenIssue(string Id)
    {
        Issue issue = await _repo.GetById(Id);
        issue.Active = true;
    }
}
