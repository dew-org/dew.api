namespace Dew.Shops.Domain;

public interface IShopRepository
{
    Task Save(Shop shop);

    Task<Shop?> FindByUser(string userId);
}
