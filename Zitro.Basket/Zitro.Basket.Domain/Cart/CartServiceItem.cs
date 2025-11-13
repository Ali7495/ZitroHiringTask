namespace Zitro.Basket.Domain;

public class CartServiceItem
{
    public int ServiceId { get; set; }
    public int Count { get; set; }
    public string Title { get; set; }
    public long Price { get; set; }
    public long? DiscountPrice { get; set; }

}
