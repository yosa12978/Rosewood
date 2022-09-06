namespace Rosewood.Services.Interfaces;

public interface IProjectService
{
    Task<IEnumerable<Project>> GetAllProjects();
    Task<Project> GetProject(string Id);
    Task DeleteProject(string Id); // for admins or for those who has created project
    Task UpdateProject(UpdateProjectRequest dto);
}
