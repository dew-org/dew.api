using Dew.Inventory.Application.Update;
using Dew.Inventory.Domain;
using Dew.Inventory.Test.Domain;

namespace Dew.Inventory.Test.Application.Update;

public class UpdateProductInventoryCommandHandlerTest
{
    private static string _existingProductSku = string.Empty;
    private const string NonExistingProductSku = "NonExistingProductCode";

    private readonly UpdateProductInventoryCommandHandler _handler;

    public UpdateProductInventoryCommandHandlerTest()
    {
        var repository = Mock.Of<IProductInventoryRepository>();

        _handler = new UpdateProductInventoryCommandHandler(new ProductInventoryUpdater(repository));

        var productInventory = ProductInventoryMother.Random();
        _existingProductSku = productInventory.Sku;

        Mock.Get(repository)
            .Setup(x => x.UpdateStock(_existingProductSku, It.IsAny<uint>()))
            .ReturnsAsync(productInventory)
            .Callback<string, uint>((_, newStock) => { productInventory.Stock = newStock; });
    }

    [Fact]
    public async Task WhenProductExists_ThenUpdateStock()
    {
        // Arrange
        var command = new UpdateProductInventoryCommand(_existingProductSku, 20);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        result.Should().NotBeNull();
        result!.Stock.Should().Be(20);
    }

    [Fact]
    public async Task WhenProductDoesNotExist_ThenReturnNull()
    {
        // Arrange
        var command = new UpdateProductInventoryCommand(NonExistingProductSku, 20);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().BeNull();
    }
}
