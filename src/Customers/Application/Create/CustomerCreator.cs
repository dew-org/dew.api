using Dew.Customers.Domain;
using Mapster;

namespace Dew.Customers.Application.Create;

public class CustomerCreator
{
    private readonly ICustomerRepository _repository;

    public CustomerCreator(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task Create(CreateCustomerCommand command)
    {
        var customer = command.Adapt<Customer>();
        await _repository.Save(customer);
    }
}
