using Dew.Shared.Domain.Bus.Command;

namespace Dew.Inventory.Application.Create;

public sealed class CreateProductInventoryCommandHandler : CommandHandler<CreateProductInventoryCommand>
{
    private readonly ProductInventoryCreator _creator;

    public CreateProductInventoryCommandHandler(ProductInventoryCreator creator)
    {
        _creator = creator;
    }

    protected override async Task Handle(CreateProductInventoryCommand request, CancellationToken cancellationToken) =>
        await _creator.Create(request);
}
