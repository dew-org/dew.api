using Dew.Shared.Domain.Bus.Query;
using Mapster;

namespace Dew.Shops.Application.FindByUser;

public sealed class FindShopByUserQueryHandler : IQueryHandler<FindShopByUserQuery, ShopResponse?>
{
    private readonly ShopFinder _finder;

    public FindShopByUserQueryHandler(ShopFinder finder)
    {
        _finder = finder;
    }

    public async Task<ShopResponse?> Handle(FindShopByUserQuery request, CancellationToken cancellationToken)
    {
        var shop = await _finder.FindByUser(request.UserId);

        return shop?.Adapt<ShopResponse>();
    }
}
