using Dew.Shops.Application.Create;
using Dew.Shops.Domain;

namespace Shops.Test.Domain;

public static class ShopMother
{
    public static Shop Random()
    {
        var faker = new Faker<Shop>()
            .CustomInstantiator(_ => new Shop())
            .RuleFor(x => x.Name, f => f.Company.CompanyName())
            .RuleFor(x => x.Nit, f => f.Random.AlphaNumeric(10))
            .RuleFor(x => x.Address, f => f.Address.FullAddress())
            .RuleFor(x => x.Phone, f => f.Phone.PhoneNumber())
            .RuleFor(x => x.Email, f => f.Internet.Email())
            .RuleFor(x => x.UserId, f => f.Random.Guid().ToString());

        return faker.Generate();
    }

    public static CreateShopCommand RandomCommand()
    {
        var faker = new Faker();

        return new CreateShopCommand(
            faker.Company.CompanyName(),
            faker.Random.AlphaNumeric(10),
            faker.Address.FullAddress(),
            faker.Phone.PhoneNumber(),
            faker.Internet.Email(),
            faker.Random.Guid().ToString()
        );
    }

    public static CreateShopCommand InvalidCommand()
    {
        var faker = new Faker();

        return new CreateShopCommand(
            faker.Company.CompanyName(),
            string.Empty,
            string.Empty,
            faker.Phone.PhoneNumber(),
            faker.Internet.Email(),
            faker.Random.Guid().ToString()
        );
    }
}
