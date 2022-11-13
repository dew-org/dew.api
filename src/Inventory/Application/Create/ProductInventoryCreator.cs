using Dew.Inventory.Domain;

namespace Dew.Inventory.Application.Create;

public sealed class ProductInventoryCreator
{
    private readonly IProductInventoryRepository _repository;

    public ProductInventoryCreator(IProductInventoryRepository repository)
    {
        _repository = repository;
    }

    public async Task Create(CreateProductInventoryCommand command)
    {
        var productInventory = command.Adapt<ProductInventory>();

        await _repository.Save(productInventory);
    }
}
