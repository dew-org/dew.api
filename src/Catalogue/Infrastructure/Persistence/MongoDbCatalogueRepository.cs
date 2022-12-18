using Dew.Catalogue.Domain;
using Dew.Shared.Domain.Persistence;
using MongoDB.Driver;

namespace Dew.Catalogue.Infrastructure.Persistence;

public class MongoDbCatalogueRepository : ICatalogueRepository
{
    private static readonly SortDefinition<Product> SortByCreationDate =
        Builders<Product>.Sort.Descending(p => p.CreatedAt);

    private readonly IMongoCollection<Product> _collection;

    public MongoDbCatalogueRepository(IMongoCollectionBuilder collectionBuilder)
    {
        _collection = collectionBuilder.Build<Product>();
    }

    public async Task Save(Product product) => await _collection.InsertOneAsync(product);

    public async Task<IEnumerable<Product>> SearchAll(int page, int pageSize) =>
        await _collection.Find(_ => true)
            .Sort(SortByCreationDate)
            .Skip(page * pageSize)
            .Limit(pageSize)
            .ToListAsync();

    public async Task<Product?> Find(string code) =>
        await _collection.Find(p => p.Code == code).FirstOrDefaultAsync();
}
