using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdZest.Api.Domain.Entities;

namespace ProdZest.Api.Data.Mappings;
public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Description).IsRequired().HasMaxLength(100);
        builder.Property(u => u.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(u => u.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(u => u.StockQuantity).IsRequired();
        builder.Property(u => u.Observation).HasMaxLength(2000);

        //Enum
        builder.Property(u => u.Situation).IsRequired().HasDefaultValueSql("0");
    }
}
