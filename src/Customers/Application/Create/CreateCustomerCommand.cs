using Dew.Shared.Domain.Bus.Command;

namespace Dew.Customers.Application.Create;

public sealed record CreateCustomerCommand(
    string Id,
    string Name,
    string LastName,
    string PhoneNumber,
    string Email
) : Command;
