using Dew.Inventory.Application.Find;
using Dew.Inventory.Domain;
using Dew.Inventory.Test.Domain;

namespace Dew.Inventory.Test.Application.Find;

public class FindProductInventoryQueryHandlerTest
{
    private static string _existingProductCode = string.Empty;
    private const string NonExistingProductCode = "NonExistingProductCode";

    private readonly FindProductInventoryQueryHandler _handler;

    public FindProductInventoryQueryHandlerTest()
    {
        var repository = Mock.Of<IProductInventoryRepository>();

        _handler = new FindProductInventoryQueryHandler(new ProductInventoryFinder(repository));

        var productInventory = ProductInventoryMother.Random();
        _existingProductCode = productInventory.Code;

        Mock.Get(repository)
            .Setup(x => x.Find(_existingProductCode))
            .ReturnsAsync(productInventory);
    }

    [Fact]
    public async Task WhenProductInventoryExists_ShouldReturnProductInventory()
    {
        // Arrange
        var query = new FindProductInventoryQuery(_existingProductCode);

        // Act
        var productInventory = await _handler.Handle(query, CancellationToken.None);

        // Assert
        productInventory.Should().NotBeNull();
        productInventory!.Code.Should().Be(_existingProductCode);
    }

    [Fact]
    public async Task WhenProductInventoryDoesNotExist_ShouldReturnNull()
    {
        // Arrange
        var query = new FindProductInventoryQuery(NonExistingProductCode);

        // Act
        var productInventory = await _handler.Handle(query, CancellationToken.None);

        // Assert
        productInventory.Should().BeNull();
    }
}
