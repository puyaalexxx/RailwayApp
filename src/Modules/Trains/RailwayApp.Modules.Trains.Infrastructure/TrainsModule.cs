using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RailwayApp.Modules.Trains.Infrastructure;

public static class TrainsModule
{
    public static IServiceCollection AddTrainsModule( this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);

        return services;
    }
    
    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
    }
}