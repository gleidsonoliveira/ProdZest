using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProdZest.Api.Data.Context;

namespace ProdZest.Api.CrossCutting.DependencyInjection.DbConfig;
public static class DbConfigDependencyInjection
{
    public static IServiceCollection AddMemoryDatabaseDependency(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ProdZestContext>(options =>
        {
            options.UseInMemoryDatabase("ProductCatalogDb");
        });

        return services;
    }
}