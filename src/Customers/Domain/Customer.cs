using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace Dew.Customers.Domain;

public class Customer
{
    public Customer()
    {
    }

    [Key] [BsonId] public string Id { get; set; } = default!;

    public string Name { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
