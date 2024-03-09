using System.Reflection;
using Application.Behaviors;
using Application.Mappings;
using FluentValidation;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(serviceConfiguration =>
        {
            serviceConfiguration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            serviceConfiguration.AddOpenBehavior(typeof(ValidationHandling<,>));
        });
        
        MappingConfig.Configure();
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(config);
        
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        return services;
    }
}