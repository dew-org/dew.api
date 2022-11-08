using Dew.Catalogue.Application.Create;
using Dew.Catalogue.Application.SearchAll;
using Microsoft.AspNetCore.Mvc;

namespace Dew.Catalogue.Api.Endpoints;

public static class CatalogueApi
{
    public static void MapCatalogueApi(this WebApplication app)
    {
        app.MapPost("/catalogue", HandlePostProduct);
        app.MapGet("/catalogue", HandleGetAllProducts);
    }

    private static async Task<IResult> HandlePostProduct([FromServices] ISender mediator,
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

    private static async Task<IResult> HandleGetAllProducts([FromServices] ISender mediator, int page, int pageSize)
    {
        var products = await mediator.Send(new SearchAllProductsQuery(page, pageSize));
        return Results.Ok(products);
    }
}
