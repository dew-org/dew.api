namespace Dew.Inventory.Domain;

public interface IProductInventoryRepository
{
    Task Save(ProductInventory productInventory);
}
