namespace Dew.Customers.Application;

public sealed record CustomerResponse(
    string Id,
    string Name,
    string LastName,
    string? Email,
    string? PhoneNumber
);
