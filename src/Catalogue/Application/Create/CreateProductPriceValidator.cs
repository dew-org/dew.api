using FluentValidation;

namespace Dew.Catalogue.Application.Create;

public sealed class CreateProductPriceValidator : AbstractValidator<CreateProductPrice>
{
    public CreateProductPriceValidator()
    {
        RuleFor(x => x.RetailPrice)
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(x => x.SalePrice)
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(x => x.Currency)
            .NotEmpty();
    }
}
