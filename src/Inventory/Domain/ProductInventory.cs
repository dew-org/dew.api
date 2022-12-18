using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace Dew.Inventory.Domain;

public class ProductInventory
{
    [Key, BsonId] public string Sku { get; set; } = default!;
    public string Code { get; set; } = default!;

    public uint Stock { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
