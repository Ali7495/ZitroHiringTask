namespace Zitro.Basket.Domain;

public class CartServiceItem
{
    public int ServiceId { get; set; }
    public int Count { get; set; }
    public required string Title { get; set; }
    public long Price { get; set; }
    public long? DiscountPrice { get; set; }

    public CartServiceItem(int serviceId, int count, string title, long price, long discountPrice)
    {
        Guard.AgainstNonNegative(serviceId, nameof(serviceId));
        Guard.AgainstNonNegative(count, nameof(count));

        Title = string.IsNullOrEmpty(title) ? throw new ArgumentNullException("Title is required!") : title;
        ServiceId = serviceId;
        Count = count;

        Price = price;
        DiscountPrice = discountPrice;
    }
}
