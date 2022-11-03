using Dew.Customers.Domain;

namespace Dew.Customers.Application.Find;

public sealed class CustomerFinder
{
    private readonly ICustomerRepository _repository;

    public CustomerFinder(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Customer?> Find(string? id) => await _repository.Find(id);
}
