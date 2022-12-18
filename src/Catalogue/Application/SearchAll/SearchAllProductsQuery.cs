using Dew.Shared.Domain.Bus.Query;

namespace Dew.Catalogue.Application.SearchAll;

public sealed record SearchAllProductsQuery(int Page, int PageSize) : Query<IEnumerable<ProductResponse>>;
