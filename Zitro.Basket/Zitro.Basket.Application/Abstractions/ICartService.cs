using Zitro.Basket.Domain;

namespace Zitro.Basket.Application;

public interface ICartService
{
    Task<List<CartServiceItem>> AddCartServiceItemAsync(CartItem cartItem, ProductProperty productProperty, CancellationToken cancellationToken = default);

}
