using Dew.Shared.Domain.Persistence;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Dew.Shared.Infrastructure.Persistence;

public class MongoCollectionBuilder : IMongoCollectionBuilder
{
    private readonly IMongoDatabase _database;
    private readonly MongoDbSettings _settings;

    public MongoCollectionBuilder(IOptions<MongoDbSettings> options)
    {
        _settings = options.Value;

        var client = new MongoClient(_settings.ConnectionString);
        _database = client.GetDatabase(_settings.DatabaseName);
    }

    public IMongoCollection<TCollection> Build<TCollection>() =>
        _database.GetCollection<TCollection>(_settings.CollectionName);
}
