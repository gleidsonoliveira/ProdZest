using Microsoft.Extensions.DependencyInjection;
using ProdZest.Api.Data.Repository;
using ProdZest.Api.Domain.Interfaces.Repository;

namespace ProdZest.Api.CrossCutting.DependencyInjection.Repository;
public static class RepositoryDependency
{
    public static IServiceCollection AddRepositoryDependency(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        return services;
    }
}
