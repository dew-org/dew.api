using Dew.Invoices.Application.Create;
using Dew.Shared.Infrastructure.Bus;

namespace Dew.Invoices.Api.Extensions.DependencyInjection;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<InvoiceCreator>();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        return services;
    }
}
