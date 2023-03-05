using BP_POC.Domain.Printers;
using BP_POC.Domain.Sales;
using BP_POC.Domain.Shops;
using BP_POC.Persistence.Triggers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BP_POC.Persistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<Shop> Shops => Set<Shop>();
    public DbSet<Printer> Printers => Set<Printer>();
    public DbSet<Sale> Sales => Set<Sale>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.EnableDetailedErrors();
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.UseTriggers(options =>
        {
            options.AddTrigger<EntityBeforeSaveTrigger>();
        });
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        // Max Length of a NVARCHAR that can be indexed
        configurationBuilder.Properties<string>().HaveMaxLength(4_000);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
