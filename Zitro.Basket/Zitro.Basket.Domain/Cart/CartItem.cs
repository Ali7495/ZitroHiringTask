using Zitro.Basket.Domain;

public class CartItem
{
    public int ProductPropertyId { get; set; }
    public int Qty { get; set; }
    public required List<CartServiceItem> ServiceItems { get; set; }

    
}