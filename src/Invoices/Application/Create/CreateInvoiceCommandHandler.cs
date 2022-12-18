using Dew.Shared.Domain.Bus.Command;

namespace Dew.Invoices.Application.Create;

public sealed class CreateInvoiceCommandHandler : ICommandHandler<CreateInvoiceCommand, string>
{
    private readonly InvoiceCreator _creator;

    public CreateInvoiceCommandHandler(InvoiceCreator creator)
    {
        _creator = creator;
    }

    public async Task<string> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken) =>
        await _creator.Create(request);
}
