using Microsoft.EntityFrameworkCore;
using StorePilot.Domain.Entities;

namespace StorePilot.Infrastructure.Data;

public class StorePilotDbContext : DbContext
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

    public DbSet<Group> Groups => Set<Group>();


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