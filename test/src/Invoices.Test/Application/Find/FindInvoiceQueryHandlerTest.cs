using Dew.Invoices.Application.Find;
using Dew.Invoices.Domain;
using Invoices.Test.Domain;
using MongoDB.Bson;

namespace Invoices.Test.Application.Find;

public class FindInvoiceQueryHandlerTest
{
    private static string _existingInvoiceId = string.Empty;
    private static readonly string NonExistingInvoiceId = ObjectId.GenerateNewId().ToString();

    private readonly FindInvoiceQueryHandler _handler;

    public FindInvoiceQueryHandlerTest()
    {
        var repository = Mock.Of<IInvoiceRepository>();
        
        _handler = new FindInvoiceQueryHandler(new InvoiceFinder(repository));

        var invoice = InvoiceMother.Random();
        _existingInvoiceId = invoice.Id.ToString();

        Mock.Get(repository)
            .Setup(x => x.Find(invoice.Id))
            .ReturnsAsync(invoice);
    }
    
    [Fact]
    public async Task WhenInvoiceExists_ThenInvoiceIsReturned()
    {
        // Arrange
        var query = new FindInvoiceQuery(_existingInvoiceId);
        
        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task WhenInvoiceNotExists_ThenReturnNull()
    {
        // Arrange
        var query = new FindInvoiceQuery(NonExistingInvoiceId);
        
        // Act
        var result = await _handler.Handle(query, CancellationToken.None);
        
        // Assert
        result.Should().BeNull();
    }
}
