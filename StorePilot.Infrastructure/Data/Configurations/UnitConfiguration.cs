using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorePilot.Domain.Entities;

namespace StorePilot.Infrastructure.Data.Configurations;

internal sealed class UnitConfiguration : IEntityTypeConfiguration<Unit>
{
    public void Configure(EntityTypeBuilder<Unit> builder)
    {
        builder.ToTable("Units");

        builder.HasKey(x => x.UnitId);

        builder.Property(x => x.UnitId)
            .HasColumnName("UnitId")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.UnitName)
            .HasColumnName("Unit")
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasDefaultValue(DateTime.Now);

        builder.HasIndex(x => x.UnitName)
            .IsUnique();

        builder.HasMany(x => x.Products)
            .WithOne(x => x.Unit)
            .HasForeignKey(x => x.UnitId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
