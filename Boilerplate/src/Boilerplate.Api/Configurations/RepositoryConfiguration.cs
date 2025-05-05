using Boilerplate.Application.Repositories;
using Boilerplate.Infrastructure.Persistence.Repositories;

namespace Boilerplate.Api.Configurations;
public static class RepositoryConfiguration
{
public static void AddRepositories(this IServiceCollection services)
    {
        services
            .AddScoped<IProjectRepository, ProjectRepository>()
            .AddScoped<IUserRepository, UserRepository>();
    }    
}
