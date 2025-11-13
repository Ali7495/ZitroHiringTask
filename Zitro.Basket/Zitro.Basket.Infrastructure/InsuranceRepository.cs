using Microsoft.EntityFrameworkCore;
using Zitro.Basket.Application;
using Zitro.Basket.Domain;

namespace Zitro.Basket.Infrastructure;

public class InsuranceRepository : IInsuranceRepository
{

    private readonly ZitroDbContext _dbContext;

    public InsuranceRepository(ZitroDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IReadOnlyList<Insurance>> GetApplicablePropertyAsync(ProductProperty property, CancellationToken cancellationToken = default)
    {
        IQueryable<Insurance> insurancesQuery = _dbContext.Insurances.AsNoTracking();


        if (property.ServiceGroupId.HasValue)
        {
            insurancesQuery = insurancesQuery.Where(x => x.ServiceGroupId == property.ServiceGroupId);
        }

        return await insurancesQuery.ToListAsync(cancellationToken);

    }

    public async Task<Insurance?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Insurances
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
