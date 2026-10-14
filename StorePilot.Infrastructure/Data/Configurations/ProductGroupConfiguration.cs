using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorePilot.Domain.Entities;

namespace StorePilot.Infrastructure.Data.Configurations;

internal sealed class ProductGroupConfiguration : IEntityTypeConfiguration<ProductGroup>
{
    public void Configure(EntityTypeBuilder<ProductGroup> builder)
    {
        builder.ToTable("Groups");

        builder.HasKey(x => x.GroupId);

        builder.Property(x => x.GroupId)
            .HasColumnName("GroupId")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasColumnName("Group")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasDefaultValue(DateTime.Now);

        builder.HasIndex(x => x.Name)
            .IsUnique();

        builder.HasMany(x => x.Products)
            .WithOne(x => x.Group)
            .HasForeignKey(x => x.GroupId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
