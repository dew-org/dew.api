using System.Net;
using System.Net.Http.Json;
using Dew.Inventory.Test.Domain;

namespace Inventory.Api.Tet.Endpoints;

public class InventoryApiTest : ApplicationContextTestCase
{
    public InventoryApiTest(ApplicationTestCase applicationTestCase) : base(applicationTestCase)
    {
    }

    [Fact]
    public async Task WhenSendValidCreateProductInventoryCommand_ThenReturnOk()
    {
        // Arrange
        var command = ProductInventoryMother.RandomCommand();

        // Act
        var response = await Client.PostAsJsonAsync("/inventory", command);

        // Assert
        response.EnsureSuccessStatusCode();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task WhenSendInvalidCreateProductInventoryCommand_ThenReturnBadRequest()
    {
        // Arrange
        var command = ProductInventoryMother.InvalidCommand();

        // Act
        var response = await Client.PostAsJsonAsync("/inventory", command);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task WhenGetAnExistingProductInventory_ThenReturnOk()
    {
        // Arrange
        var command = ProductInventoryMother.RandomCommand();
        var response = await Client.PostAsJsonAsync("/inventory", command);
        response.EnsureSuccessStatusCode();


        var id = command.Code;

        // Act
        response = await Client.GetAsync($"/inventory/{id}");

        // Assert
        response.EnsureSuccessStatusCode();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task WhenGetAnNonExistingProductInventory_ThenReturnNotFound()
    {
        // Arrange
        var id = Guid.NewGuid();

        // Act
        var response = await Client.GetAsync($"/inventory/{id}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
