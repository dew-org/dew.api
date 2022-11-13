using Dew.Inventory.Application.Create;
using Microsoft.AspNetCore.Mvc;

namespace Dew.Inventory.Api.Endpoints;

public static class InventoryApi
{
    public static void MapInventoryApi(this WebApplication app)
    {
        app.MapPost("/inventory", HandlePostProductInventory);
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
}
