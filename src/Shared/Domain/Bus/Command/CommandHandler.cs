namespace Dew.Shared.Domain.Bus.Command;

public abstract class CommandHandler<TCommand> : AsyncRequestHandler<TCommand> where TCommand : Command
{
}
