using FluentValidation;

namespace Dew.Invoices.Application.Create;

public sealed class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
{
    public CreateInvoiceCommandValidator()
    {
        RuleFor(x => x.Customer.Id)
            .NotEmpty()
            .MaximumLength(10);

        RuleFor(x => x.Customer.FullName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Currency)
            .NotEmpty()
            .MaximumLength(5);

        RuleFor(x => x.UserId)
            .NotEmpty();

        RuleFor(x => x.Items)
            .NotEmpty();

        RuleForEach(x => x.Items)
            .SetValidator(new CreateInvoiceItemValidator());
    }
}
