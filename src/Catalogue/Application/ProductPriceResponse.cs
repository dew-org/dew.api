namespace Dew.Catalogue.Application;

public sealed record ProductPriceResponse(
    decimal RetailPrice,
    decimal SalePrice,
    string Currency
);
