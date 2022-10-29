using Dew.Customers.Application.Create;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dew.Customers.Api.Endpoints;

public static class CustomerEndpoints
{
    public static void MapCustomerEndpoints(this WebApplication app)
    {
        app.MapPost("/customers",
            async ([FromServices] IMediator mediator, [FromBody] CreateCustomerCommand customer) =>
            {
                try
                {
                    await mediator.Send(customer);
                }
                catch (ValidationException e)
                {
                    var failures = e.Errors.Select(error => new
                    {
                        Property = error.PropertyName,
                        Message = error.ErrorMessage,
                    });

                    return Results.BadRequest(failures);
                }

                return Results.Ok();
            });
    }
}
