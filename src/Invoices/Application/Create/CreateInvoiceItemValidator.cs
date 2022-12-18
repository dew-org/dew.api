using FluentValidation;

namespace Dew.Invoices.Application.Create;

public class CreateInvoiceItemValidator : AbstractValidator<CreateInvoiceItem>
{
    public CreateInvoiceItemValidator()
    {
        RuleFor(x => x.Product.Id)
            .NotEmpty();
        RuleFor(x => x.Product.Name)
            .NotEmpty();

        RuleFor(x => x.Quantity)
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(x => x.Price)
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(x => x.Discount)
            .NotEmpty()
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.Tax)
            .NotEmpty()
            .GreaterThanOrEqualTo(0);
    }
}
