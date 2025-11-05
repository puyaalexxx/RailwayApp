using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RailwayApp.Modules.Tickets.Infrastructure;

public static class TicketsModule
{
    public static IServiceCollection AddTicketsModule( this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddInfrastructure(configuration);

        return services;
    }
    
    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
    }
}