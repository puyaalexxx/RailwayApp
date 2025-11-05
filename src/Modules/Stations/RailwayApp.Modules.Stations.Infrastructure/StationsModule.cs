using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RailwayApp.Modules.Stations.Infrastructure;

public static class StationsModule
{
    public static IServiceCollection AddStationsModule( this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);

        return services;
    }
    
    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        /*services.AddDbContext<AttendanceDbContext>((sp, options) =>
            options
                .UseNpgsql(
                    configuration.GetConnectionString("Database"),
                    npgsqlOptions => npgsqlOptions
                        .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Attendance))
                .UseSnakeCaseNamingConvention()
                .AddInterceptors(sp.GetRequiredService<InsertOutboxMessagesInterceptor>()));*/

        // services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<AttendanceDbContext>());
    }
}