using System.Collections.Generic;
using Zitro.Basket.Domain;

namespace Zitro.Basket.Application;

public interface IInsuranceRepository
{
    Task<IReadOnlyList<Insurance>> GetApplicablePropertyAsync(ProductProperty property, CancellationToken cancellationToken = default);
    Task<Insurance?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
}
