using Dew.Shared.Infrastructure.Bus;
using Dew.Shops.Application.Create;
using Dew.Shops.Application.FindByUser;

namespace Dew.Shops.Api.Extensions.DependencyInjection;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ShopCreator>();
        services.AddScoped<ShopFinder>();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        return services;
    }
}
