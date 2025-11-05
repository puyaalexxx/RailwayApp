using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace RailwayApp.Shared.Application;

public static class ApplicationConfiguration
{
    public static IServiceCollection AddApplication( this IServiceCollection services, Assembly[] moduleAssemblies)
    {
        // Register MediatR handlers from provided application layers (assemblies)
        /*services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(moduleAssemblies);
        });*/
        
        // Register FluentValidation validators
       // services.AddValidatorsFromAssemblies(moduleAssemblies, includeInternalTypes: true);

        // Register pipeline behaviors (optional)
        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

        return services;
    }
}