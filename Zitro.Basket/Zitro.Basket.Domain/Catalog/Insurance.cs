namespace Zitro.Basket.Domain;

public class Insurance
{
    public int Id { get; }
    public string Title { get; }
    public long Price { get; }
    public long? DiscountPrice { get; }
    /// <summary>0 = نامحدود، بالاتر از صفر = سقف مجاز به ازای هر CartItem</summary>
    public int MaxPurchaseCount { get; }
    public int? ServiceGroupId { get; }

    public Insurance(int id, string title, long price, long? discountPrice, int maxPurchaseCount, int? serviceGroupId)
    {


        Id = id;
        Title = string.IsNullOrEmpty(title) ? throw new DomainException("Title is required") : title;
        Price = price < 0 ? throw new DomainException("Price must be greater than 0") : price;
        DiscountPrice = discountPrice;
        MaxPurchaseCount = maxPurchaseCount < 0 ? throw new DomainException("MaxPurchaseCount must be greater than 0") : maxPurchaseCount;
        ServiceGroupId = serviceGroupId;
    }

    public bool IsUnLimited() => MaxPurchaseCount == 0;
}
