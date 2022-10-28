using MongoDB.Driver;

namespace Dew.Shared.Domain.Persistence;

public interface IMongoCollectionBuilder
{
    IMongoCollection<TCollection> Build<TCollection>();
}
