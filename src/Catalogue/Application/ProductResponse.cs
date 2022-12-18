namespace Dew.Catalogue.Application;

public sealed record ProductResponse(
    string Code,
    string Name,
    string Description,
    ProductPriceResponse Price,
    float Discount,
    float Tax,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);
