using Dew.Shared.Domain.Bus.Command;

namespace Dew.Inventory.Application.Update;

public sealed class
    UpdateProductInventoryCommandHandler : ICommandHandler<UpdateProductInventoryCommand, ProductInventoryResponse?>
{
    private readonly ProductInventoryUpdater _updater;

    public UpdateProductInventoryCommandHandler(ProductInventoryUpdater updater)
    {
        _updater = updater;
    }

    public async Task<ProductInventoryResponse?> Handle(UpdateProductInventoryCommand request,
        CancellationToken cancellationToken)
    {
        var result = await _updater.Update(request.Sku, request.Stock);

        return result?.Adapt<ProductInventoryResponse>();
    }
}
