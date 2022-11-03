using Dew.Shared.Domain.Bus.Query;

namespace Dew.Customers.Application.Find;

public sealed record FindCustomerQuery(string? Id) : Query<CustomerResponse?>;
