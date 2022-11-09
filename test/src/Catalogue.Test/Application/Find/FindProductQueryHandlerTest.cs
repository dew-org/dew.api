using Dew.Catalogue.Application.Find;
using Dew.Catalogue.Domain;
using Dew.Catalogue.Test.Domain;

namespace Dew.Catalogue.Test.Application.Find;

public class FindProductQueryHandlerTest
{
    private static string _existingProductCode = string.Empty;
    private const string NonExistingProductCode = "NonExistingProductCode";

    private readonly FindProductQueryHandler _handler;

    public FindProductQueryHandlerTest()
    {
        var repository = Mock.Of<ICatalogueRepository>();

        _handler = new FindProductQueryHandler(new ProductFinder(repository));

        var product = ProductMother.Random();
        _existingProductCode = product.Code;

        Mock.Get(repository)
            .Setup(r => r.Find(_existingProductCode))
            .ReturnsAsync(product);
    }
    
    [Fact]
    public async Task WhenProductExists_ThenReturnsProduct()
    {
        // Arrange
        var query = new FindProductQuery(_existingProductCode);
        
        // Act
        var result = await _handler.Handle(query, CancellationToken.None);
        
        // Assert
        result.Should().NotBeNull();
        result!.Code.Should().Be(_existingProductCode);
    }
    
    [Fact]
    public async Task WhenProductDoesNotExist_ThenReturnsNull()
    {
        // Arrange
        var query = new FindProductQuery(NonExistingProductCode);
        
        // Act
        var result = await _handler.Handle(query, CancellationToken.None);
        
        // Assert
        result.Should().BeNull();
    }
}
