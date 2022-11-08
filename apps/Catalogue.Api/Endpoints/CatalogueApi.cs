using Dew.Catalogue.Application.Create;
using Microsoft.AspNetCore.Mvc;

namespace Dew.Catalogue.Api.Endpoints;

public static class CatalogueApi
{
    public static void MapCatalogueApi(this WebApplication app)
    {
        app.MapPost("/catalogue", HandlePostProduct);
    }

    private static async Task<IResult> HandlePostProduct([FromServices] IMediator mediator,
        [FromBody] CreateProductCommand command)
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
