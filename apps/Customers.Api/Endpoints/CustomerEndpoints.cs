using Dew.Customers.Application.Create;
using Dew.Customers.Application.Find;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dew.Customers.Api.Endpoints;

public static class CustomerEndpoints
{
    public static void MapCustomerEndpoints(this WebApplication app)
    {
        app.MapPost("/customers", HandlePostCustomer);
        app.MapGet("/customers/{id}", HandleGetCustomer);
    }

    private static async Task<IResult> HandlePostCustomer([FromServices] ISender mediator,
        [FromBody] CreateCustomerCommand command)
    {
        try
        {
            await mediator.Send(command);
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
    }

    private static async Task<IResult> HandleGetCustomer([FromServices] ISender mediator,
        [FromRoute] string id)
    {
        var customer = await mediator.Send(new FindCustomerQuery(id));

        return customer is null ? Results.NotFound() : Results.Ok(customer);
    }
}
