using System.Net;
using System.Net.Http.Json;
using Invoices.Test.Domain;

namespace Invoices.Api.Test.Endpoints;

public class InvoicesApiTest : ApplicationContextTestCase
{
    public InvoicesApiTest(ApplicationTestCase applicationTestCase) : base(applicationTestCase)
    {
    }

    [Fact]
    public async Task WhenSendValidCreateInvoiceCommand_ThenReturnOk()
    {
        // Arrange
        var command = InvoiceMother.RandomCommand();

        // Act
        var response = await Client.PostAsJsonAsync("/invoices", command);

        // Assert
        response.EnsureSuccessStatusCode();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task WhenSendInvalidCreateInvoiceCommand_ThenReturnBadRequest()
    {
        // Arrange
        var command = InvoiceMother.InvalidCommand();

        // Act
        var response = await Client.PostAsJsonAsync("/invoices", command);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}
