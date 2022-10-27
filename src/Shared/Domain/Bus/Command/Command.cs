namespace Dew.Shared.Domain.Bus.Command;

public abstract record Command : IRequest;

public abstract record Command<TResponse> : IRequest<TResponse>;
