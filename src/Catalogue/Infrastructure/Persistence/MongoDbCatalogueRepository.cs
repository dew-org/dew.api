using Dew.Catalogue.Domain;
using Dew.Shared.Domain.Persistence;
using MongoDB.Driver;

namespace Dew.Catalogue.Infrastructure.Persistence;

public class MongoDbCatalogueRepository : ICatalogueRepository
{
    private readonly IMongoCollection<Product> _collection;

    public MongoDbCatalogueRepository(IMongoCollectionBuilder collectionBuilder)
    {
        _collection = collectionBuilder.Build<Product>();
    }

    public async Task Save(Product product) => await _collection.InsertOneAsync(product);
}
