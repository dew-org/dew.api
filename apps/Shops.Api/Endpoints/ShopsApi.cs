using Dew.Shops.Application.Create;
using Dew.Shops.Application.FindByUser;
using Microsoft.AspNetCore.Mvc;

namespace Dew.Shops.Api.Endpoints;

public static class ShopsApi
{
    public static void MapShopsApi(this WebApplication app)
    {
        app.MapPost("/shops", HandlePostShop);
        app.MapGet("/shops", HandleGetShop);
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

    private static async Task<IResult> HandleGetShop([FromServices] ISender mediator,
        [FromQuery] string userId)
    {
        var shop = await mediator.Send(new FindShopByUserQuery(userId));

        return shop is null ? Results.NotFound() : Results.Ok(shop);
    }
}
