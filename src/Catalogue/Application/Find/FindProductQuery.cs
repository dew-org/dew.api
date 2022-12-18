using Dew.Shared.Domain.Bus.Query;

namespace Dew.Catalogue.Application.Find;

public sealed record FindProductQuery(string Code) : Query<ProductResponse?>;
