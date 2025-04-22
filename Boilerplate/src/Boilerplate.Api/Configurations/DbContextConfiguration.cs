using Boilerplate.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Api.Configurations;

public static class DbContextConfiguration
{
    public static void AddAppDbContext(this IServiceCollection services)
    {
        services.AddScoped<AppDbContext>();

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite("DataSource=ProjetoDB.db"));
    }
}