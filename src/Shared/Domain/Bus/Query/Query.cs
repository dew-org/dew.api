namespace Dew.Shared.Domain.Bus.Query;

public abstract record Query<TResponse> : IRequest<TResponse>;
