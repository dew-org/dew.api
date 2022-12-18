using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace Dew.Invoices.Domain;

public class Customer
{
    [Key] [BsonId] public string Id { get; set; } = default!;

    public string FullName { get; set; } = default!;
}
