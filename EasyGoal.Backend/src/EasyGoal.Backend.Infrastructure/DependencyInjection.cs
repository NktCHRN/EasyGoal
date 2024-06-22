using EasyGoal.Backend.Application.Abstractions.Infrastructure.Database;
using EasyGoal.Backend.Application.Abstractions.Infrastructure.Identity;
using EasyGoal.Backend.Domain.Abstractions;
using EasyGoal.Backend.Infrastructure.Abstractions;
using EasyGoal.Backend.Infrastructure.Database;
using EasyGoal.Backend.Infrastructure.Database.Interceptors;
using EasyGoal.Backend.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EasyGoal.Backend.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddDatabase(configuration)
            .AddIdentityServices(configuration)
            .AddSingleton(TimeProvider.System)
            .Configure((Action<JsonSerializerOptions>)(opt => opt.Converters.Add(new JsonStringEnumConverter())))
            .AddAutoMapper(typeof(IInfrastructureAssemblyMarker).Assembly);
    }

    private static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<IdentityApplicationUser, IdentityRole<Guid>>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.Password.RequiredLength = 8;
            options.Password.RequireNonAlphanumeric = false;

            //options.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
            //options.Tokens.PasswordResetTokenProvider = "CustomPasswordReset";
        })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.Configure<JwtBearerConfigOptions>(configuration.GetRequiredSection("JwtBearer"));
        services.AddSingleton<IJwtTokenProvider, JwtTokenProvider>();
        services.Configure<TokenProvidersOptions>(configuration.GetRequiredSection("TokenProvidersOptions"));
        services.AddScoped<IAccountService, AccountService>();

        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        return services
                    .AddScoped<SoftDeleteInterceptor>()
                    .AddScoped<AuditableInterceptor>()
                    .AddScoped<DispatchDomainEventsInterceptor>()
                    .AddDbContext<ApplicationDbContext>((sp, options)
                        => options
                            .UseNpgsql(configuration.GetConnectionString("ApplicationDbConnection"))
                            .AddInterceptors(sp.GetRequiredService<SoftDeleteInterceptor>(), sp.GetRequiredService<AuditableInterceptor>(), sp.GetRequiredService<DispatchDomainEventsInterceptor>()))
                    .AddScoped<ITransactionProvider, TransactionProvider>()
                    .AddScoped(typeof(IRepository<>), typeof(GenericRepository<>))
                    .AddScoped<IHistoryRepository, HistoryRepository>();
    }
}
