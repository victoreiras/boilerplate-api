using Boilerplate.Application.Usecases.CreateProject;
using Boilerplate.Application.Repositories;
using Boilerplate.Infrastructure.Persistence.Context;
using Boilerplate.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Boilerplate.Application.Usecases.GetActiveProjects;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.Api.Configurations;

public static class ServicesConfig
{
    public static void AddServices(this IServiceCollection services)
    {
        services
            .AddScoped<ICreateProject, CreateProject>()
            .AddScoped<IGetActiveProjects, GetActiveProjects>()
            .AddScoped<IProjectRepository, ProjectRepository>();
    }

    public static void AddAppDbContext(this IServiceCollection services)
    {
        services.AddScoped<AppDbContext>();

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite("DataSource=ProjetoDB.db"));
    }

    public static void AddApiVersion(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });
    }

    public static void AddCache(this IServiceCollection services)
    {
        services.AddMemoryCache();
    }
}
