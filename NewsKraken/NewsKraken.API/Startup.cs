using Core.NewsAPI;

namespace NewsKraken.API;

public static class Startup
{
    public static IServiceCollection RegisterServices(this IServiceCollection service)
    {
        return service
            .AddScoped<NewsGatherer>();
    }
}