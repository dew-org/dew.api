using Dew.Shared.Domain.Bus.Query;
using Mapster;

namespace Dew.Catalogue.Application.SearchAll;

public sealed class SearchAllProductsQueryHandler : IQueryHandler<SearchAllProductsQuery, IEnumerable<ProductResponse>>
{
    private readonly ProductsSearcher _searcher;

    public SearchAllProductsQueryHandler(ProductsSearcher searcher)
    {
        _searcher = searcher;
    }

    public async Task<IEnumerable<ProductResponse>> Handle(SearchAllProductsQuery request,
        CancellationToken cancellationToken)
    {
        var products = await _searcher.SearchAll(request.Page, request.PageSize);

        return products.Adapt<IEnumerable<ProductResponse>>();
    }
}
