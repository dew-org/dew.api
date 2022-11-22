using Dew.Invoices.Application.Create;
using Dew.Invoices.Domain;
using Invoices.Test.Domain;

namespace Invoices.Test.Application.Create;

public class CreateInvoiceCommandHandlerTest
{
    private readonly IRequestHandler<CreateInvoiceCommand, Unit> _handler;
    private Invoice? _invoice;

    public CreateInvoiceCommandHandlerTest()
    {
        var repository = Mock.Of<IInvoiceRepository>();

        _handler = new CreateInvoiceCommandHandler(new InvoiceCreator(repository));

        Mock.Get(repository)
            .Setup(x => x.Save(It.IsAny<Invoice>()))
            .Callback<Invoice>(x => _invoice = x);
    }

    [Fact]
    public async Task WhenCreateInvoiceCommandIsHandled_ThenInvoiceIsCreated()
    {
        // Arrange
        var command = InvoiceMother.RandomCommand();
        
        // Act
        await _handler.Handle(command, CancellationToken.None);
        
        // Assert
        _invoice.Should().NotBeNull();
    }
}
