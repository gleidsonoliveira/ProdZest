using Microsoft.EntityFrameworkCore;
using ProdZest.Api.Data.Mappings;
using ProdZest.Api.Domain.Entities;

namespace ProdZest.Api.Data.Context;
public class ProdZestContext : DbContext
{
    public ProdZestContext(DbContextOptions<ProdZestContext> opcoes) : base(opcoes) { }

    public DbSet<Product> Product { get; set; }
    public DbSet<Category> Category { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>(new ProductMap().Configure);
        modelBuilder.Entity<Category>(new CategoryMap().Configure);
    }
}
