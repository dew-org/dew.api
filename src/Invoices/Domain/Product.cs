using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace Dew.Invoices.Domain;

public class Product
{
    [MaxLength(50)] [Key, BsonId] public string Code { get; set; } = default!;

    [MaxLength(100)] public string Name { get; set; } = default!;
}
