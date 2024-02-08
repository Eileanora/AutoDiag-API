using IntelligentDiagnostician.DAL.Configuration;
using IntelligentDiagnostician.DataModels.Models;
using Microsoft.EntityFrameworkCore;

namespace IntelligentDiagnostician.DAL.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
    {
    }

    public AppDbContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ErrorConfiguration).Assembly);
        // modelBuilder.Ignore<BaseEntity>();
        // modelBuilder.Ignore<PrimaryKeyBaseEntity>();
    }
    public DbSet<CarSystem> CarSystems {  get; set; }    
    public DbSet<User> Users { get; set; }
    public DbSet<Reading> Readings { get; set; } 
    public DbSet<Sensor> Sensors { get; set; }
    public DbSet<Error> Errors { get; set; }
    public DbSet<Role> Roles { get; set; }
}
