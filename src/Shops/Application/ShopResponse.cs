namespace Dew.Shops.Application;

public record ShopResponse(
    string Id,
    string Name,
    string Nit,
    string Address,
    string Phone,
    string Email,
    DateTime CreatedAt
);
