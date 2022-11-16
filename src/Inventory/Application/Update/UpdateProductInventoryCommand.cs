using Dew.Shared.Domain.Bus.Command;

namespace Dew.Inventory.Application.Update;

public sealed record UpdateProductInventoryCommand(string Sku, uint Stock) : Command<ProductInventoryResponse?>;
