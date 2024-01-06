using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatelogServices.DBModels.Models.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> e)
    {
        e.Property(e => e.Description)
            .IsRequired();

        e.Property(e => e.Name)
            .IsRequired();
        e.Property(e => e.UnitPrice)
            .HasColumnType("decimal(18, 2)");

        e.HasOne(d => d.Category)
            .WithMany(p => p.Products)
            .HasForeignKey(d => d.CategoryId);
    }
}
