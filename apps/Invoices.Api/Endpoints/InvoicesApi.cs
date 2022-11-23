using Dew.Invoices.Application.Create;
using Microsoft.AspNetCore.Mvc;

namespace Dew.Invoices.Api.Endpoints;

public static class InvoicesApi
{
    public static void MapInvoicesApi(this WebApplication app)
    {
        app.MapPost("/invoices", HandlePostInvoice);
    }

    private static async Task<IResult> HandlePostInvoice([FromServices] ISender mediator,
        [FromBody] CreateInvoiceCommand command)
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
}
