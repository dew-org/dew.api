using MongoDB.Bson;

namespace Dew.Invoices.Domain;

public interface IInvoiceRepository
{
    Task Save(Invoice invoice);

    Task<Invoice?> Find(ObjectId id);
}
