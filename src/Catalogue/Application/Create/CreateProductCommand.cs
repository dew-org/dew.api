using Dew.Shared.Domain.Bus.Command;

namespace Dew.Catalogue.Application.Create;

public sealed record CreateProductPrice(decimal RetailPrice, decimal SalePrice, string Currency);

public sealed record CreateProductCommand(
    string Code,
    string Name,
    string Description,
    CreateProductPrice Price,
    float Discount,
    float Tax,
    string UserId
) : Command;
