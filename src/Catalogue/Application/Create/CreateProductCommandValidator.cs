using FluentValidation;

namespace Dew.Catalogue.Application.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .MaximumLength(500);

        RuleFor(x => x.Price).SetValidator(new CreateProductPriceValidator());

        RuleFor(x => x.Discount)
            .GreaterThan(0)
            .LessThan(1);

        RuleFor(x => x.Tax)
            .GreaterThan(0)
            .LessThan(1);

        RuleFor(x => x.UserId)
            .NotEmpty();
    }
}
