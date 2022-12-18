using System.Net;
using System.Net.Http.Json;
using Shops.Test.Domain;

namespace Dew.Shops.Api.Test.Endpoints;

public class ShopsApiTest : ApplicationContextTestCase
{
    public ShopsApiTest(ApplicationTestCase applicationTestCase) : base(applicationTestCase)
    {
    }

    [Fact]
    public async Task WhenSendValidCreateShopRequest_ThenReturnOk()
    {
        // Arrange
        var command = ShopMother.RandomCommand();

        // Act
        var response = await Client.PostAsJsonAsync("/shops", command);

        // Assert
        response.EnsureSuccessStatusCode();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task WhenSendInvalidCreateShopRequest_ThenReturnBadRequest()
    {
        // Arrange
        var command = ShopMother.InvalidCommand();

        // Act
        var response = await Client.PostAsJsonAsync("/shops", command);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task WhenGetAnExistingShop_ThenReturnOk()
    {
        // Arrange
        var command = ShopMother.RandomCommand();
        var response = await Client.PostAsJsonAsync("/shops", command);
        response.EnsureSuccessStatusCode();

        // Act
        response = await Client.GetAsync($"/shops?userId={command.UserId}");

        // Assert
        response.EnsureSuccessStatusCode();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task WhenGetANonExistingShop_ThenReturnNotFound()
    {
        // Arrange
        var userId = Guid.NewGuid();

        // Act
        var response = await Client.GetAsync($"/shops?userId={userId}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
