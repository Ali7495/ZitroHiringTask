using Microsoft.EntityFrameworkCore;
using Zitro.Basket.Domain;

namespace Zitro.Basket.Infrastructure;

public class ZitroDbContext : DbContext
{
    public DbSet<Insurance> Insurances => Set<Insurance>();

    public ZitroDbContext(DbContextOptions<ZitroDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Insurance>(entity =>
        {
            entity.ToTable("Insurance");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Title)
                  .IsRequired()
                  .HasMaxLength(200);

            entity.Property(x => x.Price)
                  .IsRequired();

            entity.Property(x => x.DiscountPrice);

            entity.Property(x => x.MaxPurchaseCount)
                  .IsRequired();

            entity.Property(x => x.ServiceGroupId);
        });
    }
}
