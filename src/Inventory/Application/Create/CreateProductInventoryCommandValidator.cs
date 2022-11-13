using FluentValidation;

namespace Dew.Inventory.Application.Create;

public sealed class CreateProductInventoryCommandValidator : AbstractValidator<CreateProductInventoryCommand>
{
    public CreateProductInventoryCommandValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Sku)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Stock)
            .NotEmpty();
    }
}
