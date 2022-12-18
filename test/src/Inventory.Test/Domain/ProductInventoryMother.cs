using Bogus;
using Dew.Inventory.Application.Create;
using Dew.Inventory.Domain;

namespace Dew.Inventory.Test.Domain;

public static class ProductInventoryMother
{
    public static ProductInventory Random()
    {
        var faker = new Faker<ProductInventory>()
            .CustomInstantiator(_ => new ProductInventory())
            .RuleFor(x => x.Code, f => f.Random.AlphaNumeric(20))
            .RuleFor(x => x.Sku, f => f.Random.AlphaNumeric(20))
            .RuleFor(x => x.Stock, f => f.Random.UInt(1, 100));

        return faker.Generate();
    }

    public static CreateProductInventoryCommand RandomCommand()
    {
        var faker = new Faker();

        return new CreateProductInventoryCommand(
            faker.Random.AlphaNumeric(20),
            faker.Random.AlphaNumeric(20),
            faker.Random.UInt(1, 100));
    }

    public static CreateProductInventoryCommand InvalidCommand()
    {
        return new CreateProductInventoryCommand(
            string.Empty,
            string.Empty,
            0);
    }
}
