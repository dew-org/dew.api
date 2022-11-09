using Dew.Shared.Domain.Bus.Query;
using Mapster;

namespace Dew.Catalogue.Application.Find;

public sealed class FindProductQueryHandler : IQueryHandler<FindProductQuery, ProductResponse?>
{
    private readonly ProductFinder _finder;

    public FindProductQueryHandler(ProductFinder finder)
    {
        _finder = finder;
    }

    public async Task<ProductResponse?> Handle(FindProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _finder.Find(request.Code);

        return product?.Adapt<ProductResponse>();
    }
}
