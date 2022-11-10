using Dew.Shops.Application.Create;
using Microsoft.AspNetCore.Mvc;

namespace Dew.Shops.Api.Endpoints;

public static class ShopsApi
{
    public static void MapShopsApi(this WebApplication app)
    {
        app.MapPost("/shops", HandlePostShop);
    }

    private static async Task<IResult> HandlePostShop([FromServices] ISender mediator,
        [FromBody] CreateShopCommand command)
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
