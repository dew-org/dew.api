using Bogus;
using Dew.Invoices.Application.Create;
using Dew.Invoices.Domain;

namespace Invoices.Test.Domain;

public static class InvoiceMother
{
    public static Invoice Random()
    {
        var productFaker = new Faker<Product>()
            .RuleFor(x => x.Code, f => f.Commerce.Product())
            .RuleFor(x => x.Name, f => f.Commerce.ProductName());

        var itemFaker = new Faker<InvoiceItem>()
            .RuleFor(x => x.Product, _ => productFaker.Generate())
            .RuleFor(x => x.Quantity, f => f.Random.Int(1, 10))
            .RuleFor(x => x.Price, f => f.Random.Decimal(1, 1000))
            .RuleFor(x => x.Tax, f => f.Random.Decimal())
            .RuleFor(x => x.Discount, f => f.Random.Decimal());

        var customerFaker = new Faker<Customer>()
            .RuleFor(x => x.Id, f => f.Random.AlphaNumeric(10))
            .RuleFor(x => x.FullName, f => f.Person.FullName);

        var faker = new Faker<Invoice>()
            .CustomInstantiator(_ => new Invoice())
            .RuleFor(x => x.Customer, _ => customerFaker.Generate())
            .RuleFor(x => x.Currency, f => f.Finance.Currency().Code)
            .RuleFor(x => x.UserId, f => f.Random.AlphaNumeric(10))
            .RuleFor(x => x.Items, f => f.Make(5, () => itemFaker.Generate()));

        var invoice = faker.Generate();
        invoice.CalculateTotals();

        return invoice;
    }

    public static CreateInvoiceCommand RandomCommand()
    {
        var faker = new Faker();

        return new CreateInvoiceCommand(
            new CreateInvoiceCustomer(faker.Random.AlphaNumeric(10), faker.Person.FullName),
            faker.Finance.Currency().Code,
            Guid.NewGuid().ToString(),
            Enumerable.Range(1, 10).Select(_ => new CreateInvoiceItem(
                new CreateInvoiceItemProduct(faker.Commerce.Product(), faker.Commerce.ProductName()),
                faker.Random.Int(1, 10),
                faker.Random.Decimal(1, 1000),
                faker.Random.Decimal(),
                faker.Random.Decimal()
            )).ToList()
        );
    }

    public static CreateInvoiceCommand InvalidCommand()
    {
        var faker = new Faker();

        return new CreateInvoiceCommand(
            new CreateInvoiceCustomer(string.Empty, string.Empty),
            faker.Finance.Currency().Code,
            Guid.NewGuid().ToString(),
            Enumerable.Range(1, 10).Select(_ => new CreateInvoiceItem(
                new CreateInvoiceItemProduct(faker.Commerce.Product(), faker.Commerce.ProductName()),
                0,
                faker.Random.Decimal(1, 1000),
                faker.Random.Decimal(),
                faker.Random.Decimal()
            )).ToList()
        );
    }
}
