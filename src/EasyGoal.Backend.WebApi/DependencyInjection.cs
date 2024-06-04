using EasyGoal.Backend.Application.Abstractions.Presentation;
using EasyGoal.Backend.WebApi.OutboundParameterTransformers;
using EasyGoal.Backend.WebApi.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using System.Text.Json.Serialization;

namespace EasyGoal.Backend.WebApi;

public static class DependencyInjection
{
    public static IServiceCollection AddWebApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(IWebApiAssemblyMarker).Assembly);

        services.AddHttpContextAccessor();

        services.AddSingleton<ICurrentApplicationUser, CurrentWebApiUser>();

        services.AddAuth(configuration);

        services.AddControllers(options =>
            {
                options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
            })
            .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

        services.AddEndpointsApiExplorer();

        services.AddSwagger();

        return services;
        //.AddOptions(configuration)
        //.AddDatabase(configuration)
        //.AddBlobStorage(configuration)
        //.AddRepositories()
        //.AddMappers()
        //.AddValidators()
        //.AddServices()
        //.AddSeeders()
        //.AddAuth(configuration)
        //.AddApiControllers()
        //.AddEndpointsApiExplorer()
        //.AddSwagger();
    }

    private static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options => {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration.GetSection("JwtBearer:Issuer").Value,

                    ValidateAudience = true,
                    ValidAudience = configuration.GetSection("JwtBearer:Audience").Value,

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("JwtBearer:Secret").Value!)),
                    ValidateIssuerSigningKey = true,

                    ValidateLifetime = true
                };
            });
        services.AddAuthorization();

        return services;
    }


    //private static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
    //{
    //    return services.Configure<RouteOptions>(options => options.LowercaseUrls = true)
    //        .Configure<BlobStorageOptions>(configuration.GetSection("BlobStorageOptions"))
    //        .Configure<JwtBearerConfigOptions>(configuration.GetSection("JwtBearer"))
    //        .Configure<TokenProvidersOptions>(configuration.GetSection("TokenProvidersOptions"));
    //}

    //private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    //{
    //    return services.AddDbContext<ApplicationDbContext>(options =>
    //        options.UseSqlServer(configuration.GetConnectionString("DbConnectionString")));
    //}

    //private static IServiceCollection AddBlobStorage(this IServiceCollection services, IConfiguration configuration)
    //{
    //    services.AddAzureClients(clientBuilder =>
    //    {
    //        clientBuilder.AddBlobServiceClient(configuration.GetConnectionString("BlobStorageConnectionString"));
    //    });
    //    return services;

    //}

    //private static IServiceCollection AddRepositories(this IServiceCollection services)
    //{
    //    return services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>))
    //        .AddSingleton<IBlobRepository, BlobRepository>();
    //}

    //private static IServiceCollection AddMappers(this IServiceCollection services)
    //{
    //    return services.AddAutoMapper(config => config.AddMaps(Assembly.GetAssembly(typeof(IBusinessLogicMarker)), Assembly.GetAssembly(typeof(IWebApiMarker))));
    //}

    //private static IServiceCollection AddValidators(this IServiceCollection services)
    //{
    //    ValidatorOptions.Global.LanguageManager.Enabled = false;
    //    return services.AddValidatorsFromAssemblyContaining<IBusinessLogicMarker>();
    //}

    //private static IServiceCollection AddServices(this IServiceCollection services)
    //{
    //    return services.AddScoped<IJwtTokenProvider, JwtTokenProvider>()
    //        .AddSingleton<IImageInfoProvider, ImageInfoProvider>()
    //        .AddSingleton<IHashedFileNameProvider, HashedFileNameProvider>()
    //        .AddScoped<IRefreshTokenService, RefreshTokenService>()
    //        .AddScoped<IAccountService, AccountService>()
    //        .AddSingleton<IImageService, ImageService>()
    //        .AddScoped<IBlogService, BlogService>()
    //        .AddScoped<IPostService, PostService>()
    //        .AddScoped<ICommentService, CommentService>();
    //}

    //private static IServiceCollection AddSeeders(this IServiceCollection services)
    //{
    //    return services.AddScoped<IRoleSeeder, RoleSeeder>();
    //}

    //private static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    //{
    //    services.AddIdentity<User, IdentityRole<Guid>>(options =>
    //    {
    //        options.User.RequireUniqueEmail = true;
    //        options.Password.RequiredLength = 8;
    //        options.Password.RequireNonAlphanumeric = false;
    //        //options.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
    //        //options.Tokens.PasswordResetTokenProvider = "CustomPasswordReset";
    //    })
    //        .AddEntityFrameworkStores<ApplicationDbContext>()
    //        .AddDefaultTokenProviders();
    //    //.AddTokenProvider<CustomEmailConfirmationTokenProvider<User>>("CustomEmailConfirmation")
    //    //.AddTokenProvider<CustomPasswordResetTokenProvider<User>>("CustomPasswordReset");

    //    services.AddAuthentication(options => {
    //        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    //        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    //    })
    //        .AddJwtBearer(options =>
    //        {
    //            options.RequireHttpsMetadata = false;
    //            options.TokenValidationParameters = new TokenValidationParameters
    //            {
    //                ValidateIssuer = true,
    //                ValidIssuer = configuration.GetSection("JwtBearer:Issuer").Value,

    //                ValidateAudience = true,
    //                ValidAudience = configuration.GetSection("JwtBearer:Audience").Value,

    //                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("JwtBearer:Secret").Value!)),
    //                ValidateIssuerSigningKey = true,

    //                ValidateLifetime = true
    //            };
    //        });
    //    services.AddAuthorization();

    //    return services;
    //}

    //private static IServiceCollection AddApiControllers(this IServiceCollection services)
    //{
    //    services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
    //    return services;
    //}

    private static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        return services.AddSwaggerGen(options => {
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
            options.OperationFilter<SecurityRequirementsOperationFilter>();
        });
    }
}
