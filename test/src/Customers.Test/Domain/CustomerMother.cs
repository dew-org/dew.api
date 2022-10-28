using Bogus;
using Dew.Customers.Application.Create;
using Dew.Customers.Domain;

namespace Dew.Customers.Test.Domain;

public static class CustomerMother
{
    public static Customer Random()
    {
        var faker = new Faker<Customer>()
            .CustomInstantiator(x => new Customer())
            .RuleFor(x => x.Id, f => f.Random.AlphaNumeric(10))
            .RuleFor(x => x.Name, f => f.Person.FirstName)
            .RuleFor(x => x.LastName, f => f.Person.LastName)
            .RuleFor(x => x.Email, f => f.Person.Email)
            .RuleFor(x => x.PhoneNumber, f => f.Person.Phone);

        return faker.Generate();
    }

    public static CreateCustomerCommand RandomCommand()
    {
        var faker = new Faker();

        return new CreateCustomerCommand(
            faker.Random.AlphaNumeric(10),
            faker.Person.FirstName,
            faker.Person.LastName,
            faker.Person.Phone,
            faker.Person.Email
        );
    }
}
