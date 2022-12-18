using Dew.Catalogue.Application.SearchAll;
using Dew.Catalogue.Domain;
using Dew.Catalogue.Test.Domain;

namespace Dew.Catalogue.Test.Application.SearchAll;

public class SearchAllProductsQueryHandlerTest
{
    private readonly SearchAllProductsQueryHandler _handler;

    private const string FirstProductCode = "firstProductCode";
    private const string LastProductCode = "lastProductCode";

    public SearchAllProductsQueryHandlerTest()
    {
        var repository = Mock.Of<ICatalogueRepository>();

        _handler = new SearchAllProductsQueryHandler(new ProductsSearcher(repository));

        var products = Enumerable.Range(1, 20)
            .Select(_ => ProductMother.Random())
            .ToList();

        products.OrderBy(x => x.CreatedAt).First().Code = FirstProductCode;
        products.OrderBy(x => x.CreatedAt).Last().Code = LastProductCode;

        Mock.Get(repository)
            .Setup(x => x.SearchAll(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync((int page, int pageSize) => products
                .OrderBy(x => x.CreatedAt)
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList());
    }

    [Theory]
    [InlineData(0, 10, "firstProductCode")]
    [InlineData(1, 10, "lastProductCode")]
    public async Task WhenSearchAllProductsQueryIsHandled_ThenAllProductsAreReturned(int page, int pageSize,
        string productCode)
    {
        // Arrange
        var query = new SearchAllProductsQuery(page, pageSize);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().HaveCount(10).And.Contain(x => x.Code == productCode);
    }
}
