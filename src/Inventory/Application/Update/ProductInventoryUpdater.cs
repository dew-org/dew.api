using Dew.Inventory.Domain;

namespace Dew.Inventory.Application.Update;

public sealed class ProductInventoryUpdater
{
    private readonly IProductInventoryRepository _repository;

    public ProductInventoryUpdater(IProductInventoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductInventory?> Update(string sku, uint stock) => await _repository.UpdateStock(sku, stock);
}
