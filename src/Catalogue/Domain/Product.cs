using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace Dew.Catalogue.Domain;

public class Product
{
    public Product()
    {
    }

    [MaxLength(50)] [Key, BsonId] public string Code { get; set; } = default!;

    [MaxLength(100)] public string Name { get; set; } = default!;

    [MaxLength(500)] public string Description { get; set; } = default!;

    public ProductPrice Price { get; set; } = default!;

    public float Discount { get; set; }
    public float Tax { get; set; }

    public string UserId { get; set; } = default!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
