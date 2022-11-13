using Dew.Shared.Domain.Bus.Command;

namespace Dew.Inventory.Application.Create;

public sealed record CreateProductInventoryCommand(string Sku, string Code, uint Stock) : Command;
