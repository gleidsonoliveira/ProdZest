using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdZest.Api.Domain.Entities;

namespace ProdZest.Api.Data.Mappings;
public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Description).IsRequired().HasMaxLength(100);


        //Relacionamento 1:N Category - Products
        builder.HasMany(u => u.Products)
               .WithOne(p => p.Category)
               .HasForeignKey(p => p.CategoryId)
               .OnDelete(DeleteBehavior.Cascade);   
    }
}