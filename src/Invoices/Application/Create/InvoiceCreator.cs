using Dew.Invoices.Domain;

namespace Dew.Invoices.Application.Create;

public sealed class InvoiceCreator
{
    private readonly IInvoiceRepository _repository;

    public InvoiceCreator(IInvoiceRepository repository)
    {
        _repository = repository;
    }

    public async Task Create(CreateInvoiceCommand command)
    {
        var invoice = command.Adapt<Invoice>();

        await _repository.Save(invoice);
    }
}
