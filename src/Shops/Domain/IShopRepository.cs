namespace Dew.Shops.Domain;

public interface IShopRepository
{
    Task Save(Shop shop);
}
