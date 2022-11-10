using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dew.Shops.Domain;

public class Shop
{
    [Key, BsonId] public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

    public string Name { get; set; } = default!;
    public string Nit { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public string Email { get; set; } = default!;

    public string UserId { get; set; } = default!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
