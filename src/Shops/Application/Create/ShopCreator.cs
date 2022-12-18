using Dew.Shops.Domain;
using Mapster;

namespace Dew.Shops.Application.Create;

public sealed class ShopCreator
{
    private readonly IShopRepository _repository;

    public ShopCreator(IShopRepository repository)
    {
        _repository = repository;
    }

    public async Task Create(CreateShopCommand command)
    {
        var shop = command.Adapt<Shop>();

        await _repository.Save(shop);
    }
}
