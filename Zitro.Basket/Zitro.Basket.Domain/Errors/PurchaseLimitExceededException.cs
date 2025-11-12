namespace Zitro.Basket.Domain;

public class PurchaseLimitExceededException : DomainException
{
    public int ServiceId { get; set; }
    public int Max { get; set; }
    public int Requested { get; set; }

    public PurchaseLimitExceededException(int serviceId, int max, int requested)  
    : base($"تعداد درخواستی برای سرویس {serviceId} ({requested}) بیش از حد مجاز ({max}) است.")
    {
        ServiceId = serviceId;
        Max = max;
        Requested = requested;
    }
}
