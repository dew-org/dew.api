namespace Dew.Catalogue.Domain;

public interface ICatalogueRepository
{
    Task Save(Product product);
}
