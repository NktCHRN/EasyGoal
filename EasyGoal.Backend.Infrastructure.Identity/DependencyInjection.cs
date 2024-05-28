using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace EasyGoal.Backend.Infrastructure.Identity;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddDbContext<IdentityDbContext>(options
                => options.UseNpgsql(configuration.GetConnectionString("IdentityDbConnection")));
    }
}
