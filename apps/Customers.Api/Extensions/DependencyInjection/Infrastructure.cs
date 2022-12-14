using System.Reflection;
using Dew.Customers.Domain;
using Dew.Customers.Infrastructure.Persistence;
using Dew.Shared.Domain.Persistence;
using Dew.Shared.Helpers;
using Dew.Shared.Infrastructure.Persistence;
using FluentValidation;
using MediatR;
using MongoDB.Bson.Serialization.Conventions;

namespace Dew.Customers.Api.Extensions.DependencyInjection;

public static class Infrastructure
{
    public const string CorsPolicy = "AllowAll";

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Customers))
            .AddMediatR(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(AssemblyHelper.GetInstance(Assemblies.Customers))
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));
        services.ConfigureConventionPack();

        services.AddSingleton<IMongoCollectionBuilder, MongoCollectionBuilder>();
        services.AddScoped<ICustomerRepository, MongoDbCustomerRepository>();

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
