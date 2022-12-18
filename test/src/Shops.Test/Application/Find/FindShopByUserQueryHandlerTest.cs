using Dew.Shops.Application.FindByUser;
using Dew.Shops.Domain;
using Shops.Test.Domain;

namespace Shops.Test.Application.Find;

public class FindShopByUserQueryHandlerTest
{
    private static string _existingShopUserId = string.Empty;
    private const string NonExistingShopUserId = "non-existing-shop-user-id";
    
    private readonly FindShopByUserQueryHandler _handler;

    public FindShopByUserQueryHandlerTest()
    {
        var repository = Mock.Of<IShopRepository>();
        
        _handler = new FindShopByUserQueryHandler(new ShopFinder(repository));

        var shop = ShopMother.Random();
        _existingShopUserId = shop.UserId;

        Mock.Get(repository)
            .Setup(r => r.FindByUser(_existingShopUserId))
            .ReturnsAsync(shop);
    }
    
    [Fact]
    public async Task WhenShopExists_ShouldReturnShop()
    {
        // Arrange
        var query = new FindShopByUserQuery(_existingShopUserId);
        
        // Act
        var shop = await _handler.Handle(query, CancellationToken.None);
        
        // Assert
        shop.Should().NotBeNull();
    }
    
    [Fact]
    public async Task WhenShopDoesNotExist_ShouldReturnNull()
    {
        // Arrange
        var query = new FindShopByUserQuery(NonExistingShopUserId);
        
        // Act
        var shop = await _handler.Handle(query, CancellationToken.None);
        
        // Assert
        shop.Should().BeNull();
    }
}
