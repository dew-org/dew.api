using Dew.Shared.Domain.Bus.Command;

namespace Dew.Catalogue.Application.Create;

public class CreateProductCommandHandler : CommandHandler<CreateProductCommand>
{
    private readonly ProductCreator _creator;

    public CreateProductCommandHandler(ProductCreator creator)
    {
        _creator = creator;
    }

    protected override async Task Handle(CreateProductCommand request, CancellationToken cancellationToken) =>
        await _creator.Create(request);
}
