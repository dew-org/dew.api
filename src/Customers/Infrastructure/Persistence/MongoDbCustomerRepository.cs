using Dew.Customers.Domain;
using Dew.Shared.Domain.Persistence;
using MongoDB.Driver;

namespace Dew.Customers.Infrastructure.Persistence;

public class MongoDbCustomerRepository : ICustomerRepository
{
    private readonly IMongoCollection<Customer> _collection;

    public MongoDbCustomerRepository(IMongoCollectionBuilder collectionBuilder)
    {
        _collection = collectionBuilder.Build<Customer>();
    }

    public async Task Save(Customer customer) => await _collection.InsertOneAsync(customer);

    public async Task<Customer?> Find(string? id) =>
        await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
}
