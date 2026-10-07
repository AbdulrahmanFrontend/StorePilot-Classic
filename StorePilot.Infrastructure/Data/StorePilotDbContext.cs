using Microsoft.EntityFrameworkCore;
using StorePilot.Domain.Entities;
using StorePilot.Application.Interfaces;

namespace StorePilot.Infrastructure.Data;

public sealed class StorePilotDbContext : DbContext, IAppDbContext
{
    public StorePilotDbContext(
        DbContextOptions<StorePilotDbContext> options)
        : base(options)
    {
    }


    // --------------------------------------------------------
    // DbSets
    // --------------------------------------------------------

    public DbSet<Product> Products => Set<Product>();

    public DbSet<Unit> Units => Set<Unit>();

    public DbSet<ProductGroup> ProductGroups => Set<ProductGroup>();

    public DbSet<PaymentMethod> PaymentMethods => Set<PaymentMethod>();

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        // Apply entity configurations from this assembly.
        //
        // Later, each entity can have its own configuration
        // class instead of putting everything here.
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(StorePilotDbContext).Assembly);
    }
}
