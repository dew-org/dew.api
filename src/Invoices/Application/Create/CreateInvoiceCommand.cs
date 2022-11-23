using Dew.Shared.Domain.Bus.Command;

namespace Dew.Invoices.Application.Create;

public sealed record CreateInvoiceCommand(
    CreateInvoiceCustomer Customer,
    string Currency,
    string UserId,
    IEnumerable<CreateInvoiceItem> Items
) : Command;

public sealed record CreateInvoiceCustomer(string Id, string FullName);

public sealed record CreateInvoiceItem(
    CreateInvoiceItemProduct Product,
    int Quantity,
    decimal Price,
    decimal Discount,
    decimal Tax
);

public sealed record CreateInvoiceItemProduct(string Id, string Name);
