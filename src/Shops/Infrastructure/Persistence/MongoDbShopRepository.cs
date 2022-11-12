using Dew.Shared.Domain.Persistence;
using Dew.Shops.Domain;
using MongoDB.Driver;

namespace Dew.Shops.Infrastructure.Persistence;

public class MongoDbShopRepository : IShopRepository
{
    private readonly IMongoCollection<Shop> _collection;

    public MongoDbShopRepository(IMongoCollectionBuilder collectionBuilder)
    {
        _collection = collectionBuilder.Build<Shop>();
    }

    public async Task Save(Shop shop) => await _collection.InsertOneAsync(shop);

    public async Task<Shop?> FindByUser(string userId) =>
        await _collection.Find(x => x.UserId == userId).FirstOrDefaultAsync();
}
