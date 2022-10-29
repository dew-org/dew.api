using Dew.Customers.Application.Create;
using Dew.Shared.Infrastructure.Bus;
using MediatR;

namespace Dew.Customers.Api.Extensions.DependencyInjection;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CustomerCreator>();


        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        return services;
    }
}
