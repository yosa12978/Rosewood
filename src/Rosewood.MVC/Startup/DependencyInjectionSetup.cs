namespace Rosewood.MVC.Startup;

public static class DependencyInjectionSetup
{
    public static IServiceCollection RegisterServices(this IServiceCollection collection) 
    {
        // AddTransient, AddSingleton, etc...
        return collection;
    }
}
