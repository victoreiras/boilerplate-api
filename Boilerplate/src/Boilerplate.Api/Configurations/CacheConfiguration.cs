namespace Boilerplate.Api.Configurations;

public static class CacheConfiguration
{
    public static void AddCache(this IServiceCollection services)
    {
        services.AddMemoryCache();
    }
}