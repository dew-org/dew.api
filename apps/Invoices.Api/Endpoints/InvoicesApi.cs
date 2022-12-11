using Dew.Invoices.Application.Create;
using Dew.Invoices.Application.Find;
using Microsoft.AspNetCore.Mvc;

namespace Dew.Invoices.Api.Endpoints;

public static class InvoicesApi
{
    public static void MapInvoicesApi(this WebApplication app)
    {
        app.MapPost("/invoices", HandlePostInvoice);
        app.MapGet("/invoices/{id}", HandleGetInvoice);
    }

    private static async Task<IResult> HandlePostInvoice([FromServices] ISender mediator,
        [FromBody] CreateInvoiceCommand command)
    {
        try
        {
            var invoiceId = await mediator.Send(command);
            return Results.Ok(invoiceId);
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
    }

    private static async Task<IResult> HandleGetInvoice([FromServices] ISender mediator,
        [FromRoute] string id)
    {
        var invoice = await mediator.Send(new FindInvoiceQuery(id));

        return invoice is null ? Results.NotFound() : Results.Ok(invoice);
    }
}
