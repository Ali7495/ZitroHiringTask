using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zitro.Basket.Application;

namespace Zitro.Basket.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("SqlDatabase");

        services.AddDbContext<ZitroDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IInsuranceRepository, InsuranceRepository>();

        return services;
    }
}
