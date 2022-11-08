using Dew.Catalogue.Application.Create;
using Dew.Catalogue.Application.SearchAll;
using Dew.Shared.Infrastructure.Bus;

namespace Dew.Catalogue.Api.Extensions.DependencyInjection;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ProductCreator>();
        services.AddScoped<ProductsSearcher>();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        return services;
    }
}
