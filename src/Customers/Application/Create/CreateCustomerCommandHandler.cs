using Dew.Shared.Domain.Bus.Command;

namespace Dew.Customers.Application.Create;

public class CreateCustomerCommandHandler : CommandHandler<CreateCustomerCommand>
{
    private readonly CustomerCreator _creator;

    public CreateCustomerCommandHandler(CustomerCreator creator)
    {
        _creator = creator;
    }

    protected override async Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken) =>
        await _creator.Create(request);
}
