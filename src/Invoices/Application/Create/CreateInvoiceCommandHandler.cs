using Dew.Shared.Domain.Bus.Command;

namespace Dew.Invoices.Application.Create;

public sealed class CreateInvoiceCommandHandler : CommandHandler<CreateInvoiceCommand>
{
    private readonly InvoiceCreator _creator;

    public CreateInvoiceCommandHandler(InvoiceCreator creator)
    {
        _creator = creator;
    }

    protected override async Task Handle(CreateInvoiceCommand request, CancellationToken cancellationToken) =>
        await _creator.Create(request);
}
