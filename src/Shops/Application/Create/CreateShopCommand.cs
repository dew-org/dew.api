using Dew.Shared.Domain.Bus.Command;

namespace Dew.Shops.Application.Create;

public sealed record CreateShopCommand(
    string Name,
    string Nit,
    string Address,
    string Phone,
    string Email,
    string UserId
) : Command;
