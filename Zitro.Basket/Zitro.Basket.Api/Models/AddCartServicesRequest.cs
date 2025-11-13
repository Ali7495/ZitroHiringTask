using Zitro.Basket.Domain;

namespace Zitro.Basket.Api;

public class AddCartServicesRequest
{
    public CartItem CartItem { get; set; }
    public ProductProperty ProductProperty { get; set; }
}
