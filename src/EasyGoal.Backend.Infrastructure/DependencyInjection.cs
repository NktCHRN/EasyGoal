using EasyGoal.Backend.Application.Abstractions.Infrastructure.Identity;
using EasyGoal.Backend.Infrastructure.Database.Interceptors;
using EasyGoal.Backend.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyGoal.Backend.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddSingleton<SoftDeleteInterceptor>()
            .AddSingleton<AuditableInterceptor>()
            .AddDbContext<IdentityDbContext>((sp, options)
                => options
                    .UseNpgsql(configuration.GetConnectionString("ApplicationDbConnection"))
                    .AddInterceptors(sp.GetRequiredService<SoftDeleteInterceptor>(), sp.GetRequiredService<AuditableInterceptor>()))
            .AddScoped<IUserService, UserService>()
            .AddSingleton(TimeProvider.System);
    }
}
