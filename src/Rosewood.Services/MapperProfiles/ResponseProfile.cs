namespace Rosewood.Services.MapperProfiles;

public class ResponseProfile : Profile
{
    public ResponseProfile()
    {
        CreateMap<IssueResponse, Issue>();
        CreateMap<ProjectResponse, Project>();
        CreateMap<UserResponse, User>();
    }
}
