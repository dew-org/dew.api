using Dew.Shared.Domain.Bus.Query;
using MongoDB.Bson;

namespace Dew.Invoices.Application.Find;

public sealed class FindInvoiceQueryHandler : IQueryHandler<FindInvoiceQuery, InvoiceResponse?>
{
    private readonly InvoiceFinder _finder;

    public FindInvoiceQueryHandler(InvoiceFinder finder)
    {
        _finder = finder;
    }

    public async Task<InvoiceResponse?> Handle(FindInvoiceQuery request, CancellationToken cancellationToken)
    {
        var invoice = await _finder.Find(ObjectId.Parse(request.Id));

        return invoice?.Adapt<InvoiceResponse>();
    }
}
