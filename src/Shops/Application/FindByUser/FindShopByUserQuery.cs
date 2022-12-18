using Dew.Shared.Domain.Bus.Query;

namespace Dew.Shops.Application.FindByUser;

public sealed record FindShopByUserQuery(string UserId) : Query<ShopResponse?>;
