using Dew.Customers.Application.Find;
using Dew.Customers.Domain;
using Dew.Customers.Test.Domain;
using FluentAssertions;
using Moq;

namespace Dew.Customers.Test.Application.Find;

public class FindCustomerQueryHandlerTest
{
    private static string? _existingCustomerId;
    private const string? NonExistingCustomerId = "nonExistingCustomerId";

    private readonly FindCustomerQueryHandler _handler;

    public FindCustomerQueryHandlerTest()
    {
        var repository = Mock.Of<ICustomerRepository>();

        _handler = new FindCustomerQueryHandler(new CustomerFinder(repository));

        var customer = CustomerMother.Random();
        _existingCustomerId = customer.Id;

        Mock.Get(repository)
            .Setup(x => x.Find(_existingCustomerId))
            .ReturnsAsync(customer);
    }
    
    [Fact]
    public async Task WhenCustomerExists_ThenReturnCustomer()
    {
        var query = new FindCustomerQuery(_existingCustomerId);
        var customer = await _handler.Handle(query, CancellationToken.None);

        customer.Should().NotBeNull();
    }
    
    [Fact]
    public async Task WhenCustomerDoesNotExist_ThenReturnNull()
    {
        var query = new FindCustomerQuery(NonExistingCustomerId);
        var customer = await _handler.Handle(query, CancellationToken.None);

        customer.Should().BeNull();
    }
    
    [Fact]
    public async Task WhenCustomerIdIsNull_ThenReturnNull()
    {
        var query = new FindCustomerQuery(null);
        var customer = await _handler.Handle(query, CancellationToken.None);

        customer.Should().BeNull();
    }
}
