using Dew.Shops.Domain;

namespace Dew.Shops.Application.FindByUser;

public sealed class ShopFinder
{
    private readonly IShopRepository _repository;

    public ShopFinder(IShopRepository repository)
    {
        _repository = repository;
    }

    public async Task<Shop?> FindByUser(string userId) => await _repository.FindByUser(userId);
}
