using Microsoft.VisualBasic;
using Zitro.Basket.Domain;

namespace Zitro.Basket.Application;

public class CartService : ICartService
{

    private readonly IInsuranceRepository _insuranceRepository;

    public CartService(IInsuranceRepository insuranceRepository)
    {
        _insuranceRepository = insuranceRepository;
    }

    public async Task<List<CartServiceItem>> AddCartServiceItemAsync(CartItem cartItem, ProductProperty productProperty, CancellationToken cancellationToken = default)
    {
        if (cartItem == null)
            throw new DomainException("حتما باید یک آیتم انتخاب شود.");

        IReadOnlyList<Insurance> applicables = await _insuranceRepository.GetApplicablePropertyAsync(productProperty, cancellationToken);

        Dictionary<int, Insurance> Ids = applicables.ToDictionary(a => a.Id);

        List<CartServiceItem> cartServiceItems = new();

        foreach (CartServiceItem request in cartItem.ServiceItems)
        {
            if (!Ids.TryGetValue(request.ServiceId, out Insurance insurance))
                throw new NotFoundException($"سرویس با شناسه {request.ServiceId} یافت نشد یا برای این کالا مجاز نیست.");

            PurchaseLimitPolicy.EnsureWithinLimit(insurance, request.Count);

            CartServiceItem cartServiceItem = new()
            {
                ServiceId = insurance.Id,
                Count = request.Count,
                Title = insurance.Title,
                Price = insurance.Price,
                DiscountPrice = insurance.DiscountPrice
            };

            cartServiceItems.Add(cartServiceItem);
        }


        return cartServiceItems;
    }
}
