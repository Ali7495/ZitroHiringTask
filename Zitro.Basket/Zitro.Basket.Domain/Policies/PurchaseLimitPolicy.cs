namespace Zitro.Basket.Domain;

public static class PurchaseLimitPolicy
{
    public static void EnsureWithinLimit(Insurance service, int requestedCount)
    {
        if (requestedCount <= 0)
            throw new DomainException("At least 1 service is required!");

        if (!service.IsUnLimited() && requestedCount > service.MaxPurchaseCount)
            throw new PurchaseLimitExceededException(service.Id, service.MaxPurchaseCount, requestedCount);    
    }
}
