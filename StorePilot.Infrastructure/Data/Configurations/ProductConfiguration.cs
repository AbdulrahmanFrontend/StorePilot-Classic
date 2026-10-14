using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorePilot.Domain.Entities;

namespace StorePilot.Infrastructure.Data.Configurations;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");


        // --------------------------------------------------------
        // Primary Key
        // --------------------------------------------------------

        builder.HasKey(x => x.ProductId);

        builder.Property(x => x.ProductId)
            .HasColumnName("ProductId");


        // --------------------------------------------------------
        // Properties
        // --------------------------------------------------------

        builder.Property(x => x.Code)
            .HasColumnName("Code")
            .HasMaxLength(20);


        builder.Property(x => x.ProductName)
            .HasColumnName("ProductName")
            .IsRequired()
            .HasMaxLength(50);


        builder.Property(x => x.Quantity)
            .HasColumnName("Quantity")
            .HasDefaultValue(0);


        builder.Property(x => x.MinQuantity)
            .HasColumnName("MinQuantity")
            .HasDefaultValue(0);


        builder.Property(x => x.SalePrice)
            .HasColumnName("SalePrice")
            .HasDefaultValue(0);


        builder.Property(x => x.PurchasePrice)
            .HasColumnName("PurchasePrice")
            .HasDefaultValue(0);


        builder.Property(x => x.UnitId)
            .HasColumnName("UnitId")
            .IsRequired();


        builder.Property(x => x.GroupId)
            .HasColumnName("GroupId")
            .IsRequired();


        builder.Property(x => x.CreatedAt)
            .HasColumnName("CreatedAt")
            .HasDefaultValueSql(
                "CURRENT_TIMESTAMP");


        builder.Property(x => x.Notes)
            .HasColumnName("Notes");


        builder.Property(x => x.Active)
            .HasColumnName("Active")
            .HasDefaultValue(true);


        // --------------------------------------------------------
        // Relationships
        // --------------------------------------------------------

        builder.HasOne(x => x.Unit)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.UnitId)
            .OnDelete(DeleteBehavior.Restrict);


        builder.HasOne(x => x.Group)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.GroupId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}