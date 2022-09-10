using Rosewood.Services.Interfaces;
using Rosewood.Services.Exceptions;

namespace Rosewood.Services.Impls;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _repo;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    public ProjectService(IProjectRepository repo, IMapper mapper, IUserService userService)
    {
        _repo = repo;
        _mapper = mapper;
        _userService = userService;
    }

    public async Task DeleteProject(string Id, CurrentSession usr)
    {
        Project proj = await _repo.GetById(Id);
        if (!(proj.CreatedBy.Email != usr.Email && usr.Role != "ADMIN") || proj == null)
            throw new BadRequestException("you can't delete this project");
        await _repo.Delete(Id);
    }
    
    public async Task UpdateProject(string Id, UpdateProjectRequest dto, CurrentSession usr)
    {
        Project proj = await _repo.GetById(Id);
        if (!(proj.CreatedBy.Email != usr.Email && usr.Role != "ADMIN") || proj == null)
            throw new BadRequestException("you can't update this project");
        proj = _mapper.Map<Project>(dto);
        await _repo.Update(proj);
    }

    public async Task CreateProject(CreateProjectRequest dto, CurrentSession usr)
    {
        Project proj = new Project 
        {
            Id = Guid.NewGuid().ToString(),
            Title = dto.Title,
            Description = dto.Description,
            CreatedBy = await _userService.GetUserByEmail(usr.Email),
        };
        await _repo.Create(proj);
    }

    public async Task<IEnumerable<ProjectResponse>> GetAllProjects()
    {
        IEnumerable<Project> projects = await _repo.GetAll();
        return projects.Select(x => _mapper.Map<ProjectResponse>(x));
    }

    public async Task<ProjectResponse> GetProject(string Id)
    {
        Project proj = await _repo.GetById(Id);
        return _mapper.Map<ProjectResponse>(proj);
    }

    public async Task<Project> GetProjectM(string Id)
    {
        return await _repo.GetById(Id);
    }
}
