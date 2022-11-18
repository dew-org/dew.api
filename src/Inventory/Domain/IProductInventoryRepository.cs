namespace Dew.Inventory.Domain;

public interface IProductInventoryRepository
{
    Task Save(ProductInventory productInventory);

    Task<ProductInventory?> Find(string codeOrSku);

    Task<ProductInventory?> UpdateStock(string sku, uint newStock);
}
