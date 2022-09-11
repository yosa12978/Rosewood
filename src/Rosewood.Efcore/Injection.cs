using Microsoft.Extensions.DependencyInjection;
using Rosewood.Efcore.Data;
using Rosewood.Efcore.Repositories;

namespace Rosewood.Efcore;

public static class Injection
{
    public static IServiceCollection AddEFCore(
        this IServiceCollection services,
        string connectionString
        )
    {
        services.AddDbContext<RwContext>(options => options.UseSqlite(connectionString));
        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddSingleton<IProjectRepository, ProjectRepository>();
        services.AddSingleton<IIssueRepository, IssueRepository>();
        return services;
    }
}
