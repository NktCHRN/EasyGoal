using EasyGoal.Backend.Application.Abstractions.Infrastructure.Identity;
using EasyGoal.Backend.Infrastructure.BackgroundJobs;
using EasyGoal.Backend.Infrastructure.Database.Interceptors;
using EasyGoal.Backend.Infrastructure.Identity;
using EasyGoal.Backend.Infrastructure.Options;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EasyGoal.Backend.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddSingleton<SoftDeleteInterceptor>()
            .AddSingleton<AuditableInterceptor>()
            .AddSingleton<SaveDomainEventsInterceptor>()
            .AddDbContext<IdentityDbContext>((sp, options)
                => options
                    .UseNpgsql(configuration.GetConnectionString("ApplicationDbConnection"))
                    .AddInterceptors(sp.GetRequiredService<SoftDeleteInterceptor>(), sp.GetRequiredService<AuditableInterceptor>(), sp.GetRequiredService<SaveDomainEventsInterceptor>()))
            .AddScoped<IUserService, UserService>()
            .AddSingleton(TimeProvider.System)
            .Configure<JsonSerializerOptions>(opt => opt.Converters.Add(new JsonStringEnumConverter()))
            .Configure<OutboxOptions>(configuration.GetRequiredSection("OutboxOptions"))
            .AddQuartz(cfg =>
            {
                var jobKey = new JobKey(nameof(ProcessOutboxMessagesJob));

                cfg.AddJob<ProcessOutboxMessagesJob>(jobKey)
                    .AddTrigger(t => t
                        .ForJob(nameof(ProcessOutboxMessagesJob))
                        .WithSimpleSchedule(s => s.WithIntervalInSeconds(configuration.GetValue<int>($"OutboxOptions:{nameof(OutboxOptions.IntervalInSeconds)}"))));
            });
    }
}
