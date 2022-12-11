using Dew.Shared.Domain.Bus.Query;

namespace Dew.Invoices.Application.Find;

public sealed record FindInvoiceQuery(string Id) : Query<InvoiceResponse?>;
