using Dew.Shared.Domain.Bus.Query;

namespace Dew.Inventory.Application.Find;

public sealed record FindProductInventoryQuery(string CodeOrSku) : Query<ProductInventoryResponse?>;
