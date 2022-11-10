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
}
