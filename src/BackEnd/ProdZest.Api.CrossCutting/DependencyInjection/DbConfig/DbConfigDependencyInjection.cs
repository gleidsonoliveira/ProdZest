using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProdZest.Api.Data.Context;
using ProdZest.Api.Domain.Entities;

namespace ProdZest.Api.CrossCutting.DependencyInjection.DbConfig;
public static class DbConfigDependencyInjection
{
    public static IServiceCollection AddMemoryDatabaseDependency(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ProdZestContext>(options =>
        {
            options.UseInMemoryDatabase("ProductCatalogDb").LogTo(Console.WriteLine, LogLevel.Information).EnableSensitiveDataLogging();
        });

        #region Popula a tabela de produtos e categoria.
        using (var serviceProvider = services.BuildServiceProvider())
        {
            var context = serviceProvider.GetRequiredService<ProdZestContext>();

            //Adiciona os produtos no banco de dados

            for (int i = 1; i < 10; i++)
            {
                context.Product.Add(new Product
                {
                    Id = i,
                    Description = $"Produto Extra {i + 1}",
                    UnitPrice = 15.00m + i,
                    GrossPrice = 18.00m + i,
                    StockQuantity = 50 + i,
                    Active = true
                });
            }

            context.SaveChanges();
        }
        #endregion

        return services;
    }
}