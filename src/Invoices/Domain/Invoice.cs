using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dew.Invoices.Domain;

public class Invoice
{
    [Key, BsonId] public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

    public Customer Customer { get; set; } = default!;

    public string Currency { get; set; } = default!;
    public string UserId { get; set; }

    public IEnumerable<InvoiceItem> Items { get; } = new HashSet<InvoiceItem>();

    public decimal SubTotal { get; private set; }
    public decimal Discount { get; private set; }
    public decimal Tax { get; private set; }
    public decimal Total { get; private set; }

    public DateTime CreatedAt { get; } = DateTime.UtcNow;

    public void CalculateTotals()
    {
        SubTotal = Items.Sum(x => x.SubTotal);
        Discount = Items.Sum(x => x.Discount * x.SubTotal);
        Tax = Items.Sum(x => x.Tax * x.SubTotal);
        Total = Items.Sum(x => x.Total);
    }
}
