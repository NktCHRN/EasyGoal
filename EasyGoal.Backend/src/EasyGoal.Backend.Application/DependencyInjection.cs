using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EasyGoal.Backend.Application.MediatrBehaviors;
using MediatR.NotificationPublishers;

namespace EasyGoal.Backend.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddValidatorsFromAssembly(typeof(IApplicationAssemblyMarker).Assembly)
            .AddMediatR(cfg =>
            {
                cfg
                .RegisterServicesFromAssembly(typeof(IApplicationAssemblyMarker).Assembly)
                .AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
                cfg.Lifetime = ServiceLifetime.Transient;
            })
            .AddAutoMapper(typeof(IApplicationAssemblyMarker).Assembly);
    }
}
