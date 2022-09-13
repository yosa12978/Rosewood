using Microsoft.Extensions.DependencyInjection;
using Rosewood.Services.Impls;
using Rosewood.Services.Interfaces;

namespace Rosewood.Services;

public static class Injection
{
    public static IServiceCollection AddStandardServices(this IServiceCollection services)
    {
        services.AddSingleton<IPasswordService, MD5Service>();
        services.AddSingleton<IUserService, UserService>();
        services.AddSingleton<IProjectService, ProjectService>();
        services.AddSingleton<IIssueService, IssueService>();
        services.AddSingleton<ICommentService, CommentService>();
        return services;
    }
}
