using System.Net;
using System.Net.Http.Json;
using Dew.Customers.Test.Domain;

namespace Dew.Customers.Api.Test.Endpoints;

public class CustomersEndpointTest : ApplicationContextTestCase
{
    public CustomersEndpointTest(ApplicationTestCase applicationTestCase) : base(applicationTestCase)
    {
    }

    [Fact]
    public async Task WhenSendInvalidCreateCustomerRequest_ThenReturnBadRequest()
    {
        // Arrange
        var command = CustomerMother.RandomCommand();

        // Act
        var response = await Client.PostAsJsonAsync("/customers", command);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task WhenSendValidCreateCustomerRequest_ThenReturnOk()
    {
        // Arrange
        var command = CustomerMother.ValidCommand();

        // Act
        var response = await Client.PostAsJsonAsync("/customers", command);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task WhenGetAnExistingCustomer_ThenReturnOk()
    {
        // Arrange
        var command = CustomerMother.ValidCommand();
        var createResponse = await Client.PostAsJsonAsync("/customers", command);
        createResponse.EnsureSuccessStatusCode();

        var customerId = command.Id;

        // Act
        var response = await Client.GetAsync($"/customers/{customerId}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task WhenGetANonExistingCustomer_ThenReturnNotFound()
    {
        // Arrange
        var customerId = Guid.NewGuid();

        // Act
        var response = await Client.GetAsync($"/customers/{customerId}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
