using Dew.Inventory.Application.Create;
using Dew.Inventory.Application.Find;
using Microsoft.AspNetCore.Mvc;

namespace Dew.Inventory.Api.Endpoints;

public static class InventoryApi
{
    public static void MapInventoryApi(this WebApplication app)
    {
        app.MapPost("/inventory", HandlePostProductInventory);
        app.MapGet("/inventory/{codeOrSku}", HandleGetProductInventory);
    }

    private static async Task<IResult> HandlePostProductInventory([FromServices] ISender mediator,
        [FromBody] CreateProductInventoryCommand command)
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

    private static async Task<IResult> HandleGetProductInventory([FromServices] ISender mediator,
        [FromRoute] string codeOrSku)
    {
        var response = await mediator.Send(new FindProductInventoryQuery(codeOrSku));

        return response is null
            ? Results.NotFound()
            : Results.Ok(response);
    }
}
