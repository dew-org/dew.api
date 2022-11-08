using System.Net;
using System.Net.Http.Json;
using Dew.Catalogue.Test.Domain;

namespace Dew.Catalogue.Api.Test.Endpoints;

public class CatalogueApiTest : ApplicationContextTestCase
{
    public CatalogueApiTest(ApplicationTestCase applicationTestCase) : base(applicationTestCase)
    {
    }

    [Fact]
    public async Task WhenSendValidCreateProductRequest_ThenReturnOk()
    {
        // Arrange
        var command = ProductMother.RandomCommand();

        // Act
        var response = await Client.PostAsJsonAsync("/catalogue", command);

        // Assert
        response.EnsureSuccessStatusCode();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task WhenSendInvalidCreateProductRequest_ThenReturnBadRequest()
    {
        // Arrange
        var command = ProductMother.InvalidCommand();

        // Act
        var response = await Client.PostAsJsonAsync("/catalogue", command);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}
