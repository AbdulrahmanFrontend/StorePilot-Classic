using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorePilot.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorePilot.Infrastructure.Data.Configurations;

internal class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable("Groups");


        builder.HasKey(x => x.GroupId);

        builder.Property(x => x.GroupId)
            .HasColumnName("GroupId");


        builder.Property(x => x.GroupName)
            .HasColumnName("Group")
            .IsRequired()
            .HasMaxLength(10);


        builder.HasIndex(x => x.GroupName)
            .IsUnique();
    }
}