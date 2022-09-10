namespace Rosewood.Services.Interfaces;

public interface IProjectService
{
    Task<IEnumerable<ProjectResponse>> GetAllProjects();
    Task<ProjectResponse> GetProject(string Id);
    Task DeleteProject(string Id, CurrentSession usr); // for admins or for those who has created project
    Task UpdateProject(string Id, UpdateProjectRequest dto, CurrentSession usr);
    Task CreateProject(CreateProjectRequest dto, CurrentSession usr);
    Task<Project> GetProjectM(string Id);
}
