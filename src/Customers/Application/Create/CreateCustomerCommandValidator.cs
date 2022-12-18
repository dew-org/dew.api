using FluentValidation;

namespace Dew.Customers.Application.Create;

public sealed class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .MaximumLength(10);

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Email)
            .EmailAddress()
            .MaximumLength(100);

        RuleFor(x => x.PhoneNumber)
            .MaximumLength(15)
            .Matches(@"^[0-9]+$")
            .WithMessage("Phone number must be numeric")
            .When(x => !string.IsNullOrEmpty(x.PhoneNumber));
    }
}
