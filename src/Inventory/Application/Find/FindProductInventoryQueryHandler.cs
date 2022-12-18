using Dew.Shared.Domain.Bus.Query;

namespace Dew.Inventory.Application.Find;

public sealed class
    FindProductInventoryQueryHandler : IQueryHandler<FindProductInventoryQuery, ProductInventoryResponse?>
{
    private readonly ProductInventoryFinder _finder;

    public FindProductInventoryQueryHandler(ProductInventoryFinder finder)
    {
        _finder = finder;
    }

    public async Task<ProductInventoryResponse?> Handle(FindProductInventoryQuery request,
        CancellationToken cancellationToken)
    {
        var productInventory = await _finder.Find(request.CodeOrSku);

        return productInventory?.Adapt<ProductInventoryResponse>();
    }
}
