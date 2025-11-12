namespace Zitro.Basket.Domain;

public class ProductProperty
{
    public int Id { get; set; }
    public int? ServiceGroupId { get; set; }

    public ProductProperty(int id, int? serviceGroupId = null)
    {
        Id = id;
        ServiceGroupId = serviceGroupId;
    }
}
