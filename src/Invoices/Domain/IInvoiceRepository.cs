namespace Dew.Invoices.Domain;

public interface IInvoiceRepository
{
    Task Save(Invoice invoice);
}
