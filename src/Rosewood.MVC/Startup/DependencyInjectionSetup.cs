using Rosewood.Efcore;
using Rosewood.Services;

namespace Rosewood.MVC.Startup;

public static class DependencyInjectionSetup
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, string connectionString) 
    {
        services.AddControllersWithViews();
        services.AddEFCore(connectionString);
        services.AddStandardServices();
        return services;
    }
}
