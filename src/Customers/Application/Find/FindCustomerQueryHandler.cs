using Dew.Shared.Domain.Bus.Query;
using Mapster;

namespace Dew.Customers.Application.Find;

public sealed class FindCustomerQueryHandler : IQueryHandler<FindCustomerQuery, CustomerResponse?>
{
    private readonly CustomerFinder _finder;

    public FindCustomerQueryHandler(CustomerFinder finder)
    {
        _finder = finder;
    }

    public async Task<CustomerResponse?> Handle(FindCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer = await _finder.Find(request.Id);

        return customer?.Adapt<CustomerResponse>();
    }
}
