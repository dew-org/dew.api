using Dew.Invoices.Domain;
using Dew.Shared.Domain.Persistence;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Dew.Invoices.Infrastructure.Persistence;

public class MongoDbInvoicesRepository : IInvoiceRepository
{
    private readonly IMongoCollection<Invoice> _collection;

    public MongoDbInvoicesRepository(IMongoCollectionBuilder collectionBuilder)
    {
        _collection = collectionBuilder.Build<Invoice>();
    }

    public async Task Save(Invoice invoice) => await _collection.InsertOneAsync(invoice);

    public async Task<Invoice?> Find(ObjectId id) =>
        await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
}
