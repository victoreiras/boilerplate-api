using Boilerplate.Application.Usecases.CreateProject;
using Boilerplate.Application.Usecases.GetProjects;
using Boilerplate.Application.Usecases.GetProjectById;
using Boilerplate.Application.Usecases.Login;
using Boilerplate.Application.ExternalServices;
using Boilerplate.Infrastructure.ExternalServices;

namespace Boilerplate.Api.Configurations;

public static class ServicesConfig
{
    public static void AddServices(this IServiceCollection services)
    {
        services
            .AddScoped<ICreateProject, CreateProject>()
            .AddScoped<IGetProjects, GetProjects>()
            .AddScoped<IGetProjectById, GetProjectById>()
            .AddScoped<ILogin, Login>()
            .AddScoped<IJwtService, JwtService>();
    }    
}
