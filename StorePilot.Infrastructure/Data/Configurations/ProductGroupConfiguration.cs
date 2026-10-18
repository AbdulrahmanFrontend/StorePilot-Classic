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

        builder.Property(x => x.GroupName)
            .HasColumnName("Group")
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasDefaultValue(DateTime.Now);

        builder.HasIndex(x => x.GroupName)
            .IsUnique();

        builder.HasMany(x => x.Products)
            .WithOne(x => x.Group)
            .HasForeignKey(x => x.GroupId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
