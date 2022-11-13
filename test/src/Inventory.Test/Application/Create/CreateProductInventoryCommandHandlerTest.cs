using Dew.Inventory.Application.Create;
using Dew.Inventory.Domain;
using Dew.Inventory.Test.Domain;

namespace Dew.Inventory.Test.Application.Create;

public class CreateProductInventoryCommandHandlerTest
{
    private readonly IRequestHandler<CreateProductInventoryCommand, Unit> _handler;
    private ProductInventory? _productInventory;

    public CreateProductInventoryCommandHandlerTest()
    {
        var repository = Mock.Of<IProductInventoryRepository>();

        _handler = new CreateProductInventoryCommandHandler(new ProductInventoryCreator(repository));

        Mock.Get(repository)
            .Setup(x => x.Save(It.IsAny<ProductInventory>()))
            .Callback<ProductInventory>(x => _productInventory = x);
    }

    [Fact]
    public async Task WhenCreateProductInventoryCommandIsHandled_ThenProductInventoryIsCreated()
    {
        // Arrange
        var command = ProductInventoryMother.RandomCommand();

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        _productInventory.Should().NotBeNull();
    }
}
