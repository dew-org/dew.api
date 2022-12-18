using Dew.Invoices.Domain;

namespace Dew.Invoices.Application.Create;

public sealed class InvoiceCreator
{
    private readonly IInvoiceRepository _repository;

    public InvoiceCreator(IInvoiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<string> Create(CreateInvoiceCommand command)
    {
        var invoice = command.Adapt<Invoice>();
        invoice.CalculateTotals();

        await _repository.Save(invoice);

        return invoice.Id.ToString();
    }
}
