using Boilerplate.Application.Usecases.CreateProject;
using Boilerplate.Application.Usecases.GetActiveProjects;
using Boilerplate.Application.Usecases.GetProjectById;

namespace Boilerplate.Api.Configurations;

public static class ServicesConfig
{
    public static void AddServices(this IServiceCollection services)
    {
        services
            .AddScoped<ICreateProject, CreateProject>()
            .AddScoped<IGetActiveProjects, GetActiveProjects>()
            .AddScoped<IGetProjectById, GetProjectById>();
    }    
}
