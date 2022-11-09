using Dew.Catalogue.Application.Create;
using Dew.Catalogue.Application.Find;
using Dew.Catalogue.Application.SearchAll;
using Microsoft.AspNetCore.Mvc;

namespace Dew.Catalogue.Api.Endpoints;

public static class CatalogueApi
{
    public static void MapCatalogueApi(this WebApplication app)
    {
        app.MapPost("/catalogue", HandlePostProduct);
        app.MapGet("/catalogue", HandleGetAllProducts);
        app.MapGet("/catalogue/{code}", HandleGetProduct);
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

    private static async Task<IResult> HandleGetProduct([FromServices] ISender mediator, [FromRoute] string code)
    {
        var product = await mediator.Send(new FindProductQuery(code));

        return product is null ? Results.NotFound() : Results.Ok(product);
    }
}
