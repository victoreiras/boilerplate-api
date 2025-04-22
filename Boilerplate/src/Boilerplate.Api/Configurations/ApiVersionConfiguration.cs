using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.Api.Configurations;

public static class ApiVersionConfiguration
{
    public static void AddApiVersion(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });
    }
}
