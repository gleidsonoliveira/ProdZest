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

            //Adiciona as categorias no banco de dados
            context.Category.AddRange(
                new Category
                {
                    Id = 1,
                    Description = "Categoria A"
                },
                new Category
                {
                    Id = 2,
                    Description = "Categoria B"
                }
            );

            //Adiciona os produtos no banco de dados
            context.Product.AddRange(
                new Product
                {
                    Id = 1,
                    Description = "Produto A",
                    UnitPrice = 10.00m,
                    GrossPrice = 12.00m,
                    StockQuantity = 100,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Description = "Produto B",
                    UnitPrice = 20.00m,
                    GrossPrice = 24.00m,
                    StockQuantity = 200,
                    CategoryId = 2
                }
            );
            context.SaveChanges();
        }
        #endregion

        return services;
    }
}