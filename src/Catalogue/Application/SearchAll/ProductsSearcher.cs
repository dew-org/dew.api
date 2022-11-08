using Dew.Catalogue.Domain;

namespace Dew.Catalogue.Application.SearchAll;

public sealed class ProductsSearcher
{
    private readonly ICatalogueRepository _repository;

    public ProductsSearcher(ICatalogueRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Product>> SearchAll(int page, int pageSize) =>
        await _repository.SearchAll(page, pageSize);
}
