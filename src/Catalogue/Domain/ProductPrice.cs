namespace Dew.Catalogue.Domain;

public class ProductPrice
{
    public ProductPrice()
    {
    }

    public decimal RetailPrice { get; set; }
    public decimal SalePrice { get; set; }
    public string Currency { get; set; } = default!;
}
