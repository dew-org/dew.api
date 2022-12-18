using System.Reflection;
using Dew.Shared.Domain.Persistence;
using Dew.Shared.Helpers;
using Dew.Shared.Infrastructure.Persistence;
using Dew.Shops.Domain;
using Dew.Shops.Infrastructure.Persistence;
using MongoDB.Bson.Serialization.Conventions;

namespace Dew.Shops.Api.Extensions.DependencyInjection;

public static class Infrastructure
{
    public const string CorsPolicy = "CorsPolicy";

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Shops))
            .AddMediatR(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(AssemblyHelper.GetInstance(Assemblies.Shops))
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));
        services.ConfigureConventionPack();

        services.AddSingleton<IMongoCollectionBuilder, MongoCollectionBuilder>();
        services.AddScoped<IShopRepository, MongoDbShopRepository>();

        services.AddRouting(route => route.LowercaseUrls = true);
        services.ConfigureCors();

        return services;
    }

    private static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(CorsPolicy, policyBuilder =>
            {
                policyBuilder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
    }

    private static void ConfigureConventionPack(this IServiceCollection services)
    {
        var conventionPack = new ConventionPack
        {
            new CamelCaseElementNameConvention()
        };

        ConventionRegistry.Register("camelCase", conventionPack, _ => true);
    }
}
