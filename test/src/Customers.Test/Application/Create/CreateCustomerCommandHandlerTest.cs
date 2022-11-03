using Dew.Customers.Application.Create;
using Dew.Customers.Domain;
using Dew.Customers.Test.Domain;
using FluentAssertions;
using MediatR;
using Moq;

namespace Dew.Customers.Test.Application.Create;

public class CreateCustomerCommandHandlerTest
{
    private readonly IRequestHandler<CreateCustomerCommand, Unit> _handler;
    private Customer? _customer;

    public CreateCustomerCommandHandlerTest()
    {
        var repository = Mock.Of<ICustomerRepository>();
        _handler = new CreateCustomerCommandHandler(new CustomerCreator(repository));

        Mock.Get(repository).Setup(x => x.Save(It.IsAny<Customer>()))
            .Returns<Customer>(customer =>
            {
                _customer = customer;
                return Task.CompletedTask;
            });
    }

    [Fact]
    public async Task WhenCreateCustomerCommandIsHandled_ThenCustomerIsCreated()
    {
        // Arrange
        var command = CustomerMother.RandomCommand();

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        _customer.Should().NotBeNull();
    }
}
