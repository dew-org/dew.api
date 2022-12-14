namespace Dew.Shared.Domain.Bus.Command;

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : Command<TResponse>
{
}
