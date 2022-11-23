using Dew.Invoices.Domain;
using Dew.Shared.Domain.Persistence;
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
}
