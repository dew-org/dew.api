using Dew.Invoices.Domain;
using MongoDB.Bson;

namespace Dew.Invoices.Application.Find;

public sealed class InvoiceFinder
{
    private readonly IInvoiceRepository _repository;

    public InvoiceFinder(IInvoiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<Invoice?> Find(ObjectId id) => await _repository.Find(id);
}
