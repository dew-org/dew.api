using System.Net;
using System.Net.Http.Json;
using Dew.Catalogue.Application;
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

    [Fact]
    public async Task WhenGetAllProducts_ThenReturnProducts()
    {
        // Arrange
        var tasks = Enumerable.Range(0, 20)
            .Select(_ => ProductMother.RandomCommand())
            .Select(x => Client.PostAsJsonAsync("/catalogue", x))
            .ToList();
        
        await Task.WhenAll(tasks);
        
        // Act
        var response = await Client.GetAsync("/catalogue?pageSize=10&page=0");
        
        // Assert
        response.EnsureSuccessStatusCode();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        var products = await response.Content.ReadFromJsonAsync<List<ProductResponse>>();
        
        products.Should().NotBeNull();
        products.Should().HaveCount(10);
    }
    
    [Fact]
    public async Task WhenGetAnExistingProduct_ThenReturnProduct()
    {
        // Arrange
        var command = ProductMother.RandomCommand();
        var response = await Client.PostAsJsonAsync("/catalogue", command);
        response.EnsureSuccessStatusCode();

        // Act
        response = await Client.GetAsync($"/catalogue/{command.Code}");
        
        // Assert
        response.EnsureSuccessStatusCode();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        var productResponse = await response.Content.ReadFromJsonAsync<ProductResponse>();
        
        productResponse.Should().NotBeNull();
        productResponse!.Code.Should().Be(command.Code);
    }
    
    [Fact]
    public async Task WhenGetANonExistingProduct_ThenReturnNotFound()
    {
        // Arrange
        var command = ProductMother.RandomCommand();

        // Act
        var response = await Client.GetAsync($"/catalogue/{command.Code}");
        
        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
