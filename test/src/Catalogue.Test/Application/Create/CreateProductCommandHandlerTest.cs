using Dew.Catalogue.Application.Create;
using Dew.Catalogue.Domain;
using Dew.Catalogue.Test.Domain;

namespace Dew.Catalogue.Test.Application.Create;

public class CreateProductCommandHandlerTest
{
    private readonly IRequestHandler<CreateProductCommand, Unit> _handler;
    private Product? _product;

    public CreateProductCommandHandlerTest()
    {
        var repository = Mock.Of<ICatalogueRepository>();

        _handler = new CreateProductCommandHandler(new ProductCreator(repository));

        Mock.Get(repository)
            .Setup(x => x.Save(It.IsAny<Product>()))
            .Callback<Product>(x => _product = x);
    }

    [Fact]
    public async Task WhenCreateProductCommandIsHandled_ThenProductIsCreated()
    {
        // Arrange
        var command = ProductMother.RandomCommand();

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        _product.Should().NotBeNull();
    }
}
