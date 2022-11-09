using Dew.Catalogue.Domain;

namespace Dew.Catalogue.Application.Find;

public sealed class ProductFinder
{
    private readonly ICatalogueRepository _repository;

    public ProductFinder(ICatalogueRepository repository)
    {
        _repository = repository;
    }

    public async Task<Product?> Find(string code) => await _repository.Find(code);
}
