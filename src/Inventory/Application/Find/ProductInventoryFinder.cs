using Dew.Inventory.Domain;

namespace Dew.Inventory.Application.Find;

public sealed class ProductInventoryFinder
{
    private readonly IProductInventoryRepository _repository;

    public ProductInventoryFinder(IProductInventoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductInventory?> Find(string codeOrSku) => await _repository.Find(codeOrSku);
}
