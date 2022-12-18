using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dew.Invoices.Domain;

public class InvoiceItem
{
    [Key, BsonId] public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

    public Product Product { get; set; } = default!;

    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public decimal Discount { get; set; }
    public decimal Tax { get; set; }

    [AdaptIgnore]
    public decimal SubTotal => Quantity * Price;

    [AdaptIgnore]
    public decimal Total => (SubTotal * (1 + Tax)) * (1 - Discount);
}
