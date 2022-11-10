using Dew.Shared.Domain.Bus.Command;

namespace Dew.Shops.Application.Create;

public sealed class CreateShopCommandHandler : CommandHandler<CreateShopCommand>
{
    private readonly ShopCreator _creator;

    public CreateShopCommandHandler(ShopCreator creator)
    {
        _creator = creator;
    }

    protected override async Task Handle(CreateShopCommand request, CancellationToken cancellationToken) =>
        await _creator.Create(request);
}
