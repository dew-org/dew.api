using Bogus;
using Dew.Invoices.Application.Create;
using Dew.Invoices.Domain;

namespace Invoices.Test.Domain;

public static class InvoiceMother
{
    public static Invoice Random()
    {
        var itemFaker = new Faker<InvoiceItem>()
            .RuleFor(x => x.Product.Code, f => f.Commerce.Product())
            .RuleFor(x => x.Product.Name, f => f.Commerce.ProductName())
            .RuleFor(x => x.Quantity, f => f.Random.Int(1, 10))
            .RuleFor(x => x.Price, f => f.Random.Decimal(1, 1000))
            .RuleFor(x => x.Tax, f => f.Random.Decimal())
            .RuleFor(x => x.Discount, f => f.Random.Decimal());

        var faker = new Faker<Invoice>()
            .CustomInstantiator(_ => new Invoice())
            .RuleFor(x => x.Customer.Id, f => f.Random.AlphaNumeric(10))
            .RuleFor(x => x.Customer.FullName, f => f.Person.FullName)
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
            Enumerable.Range(1, 10).Select(_ => new CreateInvoiceItem(
                new CreateInvoiceItemProduct(faker.Commerce.Product(), faker.Commerce.ProductName()),
                faker.Random.Int(1, 10),
                faker.Random.Decimal(1, 1000),
                faker.Random.Decimal(),
                faker.Random.Decimal()
            ))
        );
    }

    public static CreateInvoiceCommand InvalidCommand()
    {
        var faker = new Faker();

        return new CreateInvoiceCommand(
            new CreateInvoiceCustomer(string.Empty, string.Empty),
            Enumerable.Range(1, 10).Select(_ => new CreateInvoiceItem(
                new CreateInvoiceItemProduct(faker.Commerce.Product(), faker.Commerce.ProductName()),
                0,
                faker.Random.Decimal(1, 1000),
                faker.Random.Decimal(),
                faker.Random.Decimal()
            ))
        );
    }
}
