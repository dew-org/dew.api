using Dew.Inventory.Application.Create;
using Dew.Inventory.Application.Find;
using Dew.Inventory.Application.Update;
using Dew.Shared.Infrastructure.Bus;

namespace Dew.Inventory.Api.Extensions.DependencyInjection;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ProductInventoryCreator>();
        services.AddScoped<ProductInventoryFinder>();
        services.AddScoped<ProductInventoryUpdater>();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        return services;
    }
}
