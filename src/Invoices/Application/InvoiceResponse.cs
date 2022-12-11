namespace Dew.Invoices.Application;

public sealed record InvoiceResponse(
    InvoiceResponseCustomer Customer,
    string Currency,
    IEnumerable<InvoiceItemResponse> Items
);

public sealed record InvoiceResponseCustomer(string Id, string FullName);

public sealed record InvoiceItemResponse(
    InvoiceItemProductResponse Product,
    int Quantity,
    decimal Price,
    decimal Discount,
    decimal Tax
);

public sealed record InvoiceItemProductResponse(string Id, string Name);
