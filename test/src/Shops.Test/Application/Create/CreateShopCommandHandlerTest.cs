using Dew.Shops.Application.Create;
using Dew.Shops.Domain;
using Shops.Test.Domain;

namespace Shops.Test.Application.Create;

public class CreateShopCommandHandlerTest
{
    private readonly IRequestHandler<CreateShopCommand, Unit> _handler;
    private Shop? _shop;

    public CreateShopCommandHandlerTest()
    {
        var repository = Mock.Of<IShopRepository>();

        _handler = new CreateShopCommandHandler(new ShopCreator(repository));

        Mock.Get(repository)
            .Setup(x => x.Save(It.IsAny<Shop>()))
            .Callback<Shop>(x => _shop = x);
    }

    [Fact]
    public async Task WhenCreateShopCommandIsHandled_ThenShopIsCreated()
    {
        // Arrange
        var command = ShopMother.RandomCommand();

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        _shop.Should().NotBeNull();
    }
}
