using Dew.Catalogue.Domain;
using Mapster;

namespace Dew.Catalogue.Application.Create;

public sealed class ProductCreator
{
    private readonly ICatalogueRepository _repository;

    public ProductCreator(ICatalogueRepository repository)
    {
        _repository = repository;
    }

    public async Task Create(CreateProductCommand command)
    {
        var product = command.Adapt<Product>();

        await _repository.Save(product);
    }
}
