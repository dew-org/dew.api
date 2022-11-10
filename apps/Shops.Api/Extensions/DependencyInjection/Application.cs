using Dew.Shared.Infrastructure.Bus;
using Dew.Shops.Application.Create;

namespace Dew.Shops.Api.Extensions.DependencyInjection;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ShopCreator>();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        return services;
    }
}
