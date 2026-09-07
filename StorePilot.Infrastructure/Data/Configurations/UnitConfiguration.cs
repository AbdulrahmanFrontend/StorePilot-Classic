using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorePilot.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorePilot.Infrastructure.Data.Configurations;

internal class UnitConfiguration : IEntityTypeConfiguration<Unit>
{
    public void Configure(EntityTypeBuilder<Unit> builder)
    {
        builder.ToTable("Units");


        builder.HasKey(x => x.UnitId);

        builder.Property(x => x.UnitId)
            .HasColumnName("UnitId");


        builder.Property(x => x.UnitName)
            .HasColumnName("Unit")
            .IsRequired()
            .HasMaxLength(10);


        builder.HasIndex(x => x.UnitName)
            .IsUnique();
    }
}