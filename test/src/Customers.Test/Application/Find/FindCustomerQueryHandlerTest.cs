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
        // Arrange
        var query = new FindCustomerQuery(_existingCustomerId);

        // Act
        var customer = await _handler.Handle(query, CancellationToken.None);

        // Assert
        customer.Should().NotBeNull();
    }

    [Fact]
    public async Task WhenCustomerDoesNotExist_ThenReturnNull()
    {
        // Arrange
        var query = new FindCustomerQuery(NonExistingCustomerId);

        // Act
        var customer = await _handler.Handle(query, CancellationToken.None);

        // Assert
        customer.Should().BeNull();
    }

    [Fact]
    public async Task WhenCustomerIdIsNull_ThenReturnNull()
    {
        // Arrange
        var query = new FindCustomerQuery(null);

        // Act
        var customer = await _handler.Handle(query, CancellationToken.None);

        // Assert
        customer.Should().BeNull();
    }
}
