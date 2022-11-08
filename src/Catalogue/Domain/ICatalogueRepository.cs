namespace Dew.Catalogue.Domain;

public interface ICatalogueRepository
{
    Task Save(Product product);

    Task<IEnumerable<Product>> SearchAll(int page, int pageSize);
}
