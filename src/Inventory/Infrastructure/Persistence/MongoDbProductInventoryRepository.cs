using Dew.Inventory.Domain;
using Dew.Shared.Domain.Persistence;
using MongoDB.Driver;

namespace Dew.Inventory.Infrastructure.Persistence;

public class MongoDbProductInventoryRepository : IProductInventoryRepository
{
    private readonly IMongoCollection<ProductInventory> _collection;

    public MongoDbProductInventoryRepository(IMongoCollectionBuilder collectionBuilder)
    {
        _collection = collectionBuilder.Build<ProductInventory>();
    }


    public async Task Save(ProductInventory productInventory) => await _collection.InsertOneAsync(productInventory);

    public async Task<ProductInventory?> Find(string codeOrSku) =>
        await _collection.Find(x => x.Code == codeOrSku || x.Sku == codeOrSku).FirstOrDefaultAsync();
}
