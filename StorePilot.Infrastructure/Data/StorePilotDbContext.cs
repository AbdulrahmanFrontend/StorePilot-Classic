using Microsoft.EntityFrameworkCore;

namespace StorePilot.Infrastructure.Data;

public class StorePilotDbContext : DbContext
{
    public StorePilotDbContext(
        DbContextOptions<StorePilotDbContext> options)
        : base(options)
    {
    }

    // DbSets will be added here as the EF Core entities are implemented.

    // Example:
    //
    // public DbSet<Product> Products => Set<Product>();
    // public DbSet<Customer> Customers => Set<Customer>();
    // public DbSet<Supplier> Suppliers => Set<Supplier>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // EF Core entity configurations will be added here gradually.
        //
        // The SQL schema remains the initial database creation source.
        // Business operations should NOT be implemented here.
    }
}