using Microsoft.Extensions.DependencyInjection;
using ProdZest.Api.Domain.Interfaces.Service;
using ProdZest.Api.Service.Services;

namespace ProdZest.Api.CrossCutting.DependencyInjection.Service;
public static class ServiceDependencyInjection
{
    public static IServiceCollection AddServiceDependency(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        return services;
    }
}
