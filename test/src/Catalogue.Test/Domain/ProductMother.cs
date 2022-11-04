using Bogus;
using Dew.Catalogue.Application.Create;
using Dew.Catalogue.Domain;

namespace Catalogue.Test.Domain;

public static class ProductMother
{
    public static Product Random()
    {
        var priceFaker = new Faker<ProductPrice>()
            .CustomInstantiator(x => new ProductPrice())
            .RuleFor(x => x.RetailPrice, f => f.Random.Decimal(1, 100))
            .RuleFor(x => x.SalePrice, f => f.Random.Decimal(1, 100))
            .RuleFor(x => x.Currency, f => f.Finance.Currency().Code);

        var faker = new Faker<Product>()
            .CustomInstantiator(x => new Product())
            .RuleFor(x => x.Code, f => f.Random.AlphaNumeric(20))
            .RuleFor(x => x.Name, f => f.Commerce.ProductName())
            .RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
            .RuleFor(x => x.Discount, f => f.Random.Float())
            .RuleFor(x => x.Tax, f => f.Random.Float())
            .RuleFor(x => x.Price, f => priceFaker.Generate())
            .RuleFor(x => x.UserId, f => f.Random.Guid().ToString());

        return faker.Generate();
    }

    public static CreateProductCommand RandomCommand()
    {
        var faker = new Faker();

        return new CreateProductCommand(
            faker.Random.AlphaNumeric(20),
            faker.Commerce.ProductName(),
            faker.Commerce.ProductDescription(),
            new CreateProductPrice(
                faker.Random.Decimal(1, 100),
                faker.Random.Decimal(1, 100),
                faker.Finance.Currency().Code
            ),
            faker.Random.Float(),
            faker.Random.Float(),
            faker.Random.Guid().ToString()
        );
    }
}
