using Zitro.Basket.Domain;

public class CartItem
{
    public int ProductPropertyId { get; set; }
    public int Qty { get; set; }
    public required List<CartServiceItem> ServiceItems { get; set; }

    public CartItem(int productPropertyId, int qty, IEnumerable<CartServiceItem> serviceItems)
    {
        Guard.AgainstNonNegative(qty, nameof(qty));
        ProductPropertyId = productPropertyId;
        Qty = qty;
        ServiceItems = serviceItems?.ToList() ?? new List<CartServiceItem>();
    }

    public void IncreaseQty(int number)
    {
        Guard.AgainstNonNegative(number, nameof(number));
        Qty += number;
    }

    public void ReplaceServiceItems(IEnumerable<CartServiceItem> serviceItems)
    {
        ServiceItems.Clear();
        ServiceItems.AddRange(serviceItems);
    }
}