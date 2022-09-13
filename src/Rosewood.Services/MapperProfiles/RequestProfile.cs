namespace Rosewood.Services.MapperProfiles;

public class RequestProfile : Profile 
{
    public RequestProfile() 
    {
        CreateMap<CreateProjectRequest, Project>();
        CreateMap<UpdateProjectRequest, Project>();
        
        CreateMap<UpdateIssueRequest, Issue>();
        CreateMap<CreateIssueRequest, Issue>();

        CreateMap<UserCreateRequest, User>();

        CreateMap<CreateCommentRequest, Comment>();
        CreateMap<UpdateCommentRequest, Comment>();
    }
} 