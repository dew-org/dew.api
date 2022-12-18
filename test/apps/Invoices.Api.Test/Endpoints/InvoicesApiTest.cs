using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Invoices.Test.Domain;
using MongoDB.Bson;

namespace Invoices.Api.Test.Endpoints;

public class InvoicesApiTest : ApplicationContextTestCase
{
    public InvoicesApiTest(ApplicationTestCase applicationTestCase) : base(applicationTestCase)
    {
    }

    [Fact]
    public async Task HandlePostInvoice_ShouldReturnOk_WhenInvoiceIsValid()
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
    public async Task HandlePostInvoice_ShouldReturnBadRequest_WhenInvoiceIsInvalid()
    {
        // Arrange
        var command = InvoiceMother.InvalidCommand();

        // Act
        var response = await Client.PostAsJsonAsync("/invoices", command);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task HandleGetInvoice_ShouldReturnOk_WhenInvoiceExist()
    {
        // Arrange
        var command = InvoiceMother.RandomCommand();
        var createResponse = await Client.PostAsJsonAsync("/invoices", command);
        createResponse.EnsureSuccessStatusCode();

        var content = await createResponse.Content.ReadAsStringAsync();
        var invoiceId = JsonSerializer.Deserialize<string>(content);

        // Act
        var response = await Client.GetAsync($"/invoices/{invoiceId}");

        // Assert
        response.EnsureSuccessStatusCode();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task HandleGetInvoice_ShouldReturnNotFound_WhenInvoiceDoesNotExist()
    {
        // Arrange
        var invoiceId = ObjectId.GenerateNewId().ToString();

        // Act
        var response = await Client.GetAsync($"/invoices/{invoiceId}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
