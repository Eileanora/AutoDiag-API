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
    DbSet<CarSystem> SystemCars {  get; set; }    
    DbSet<User> Users { get; set; }
    DbSet<Reading> Readings { get; set; } 
    DbSet<Sensor> Sensors { get; set; }
    DbSet<Error> Errors { get; set; }
    DbSet<Role> Roles { get; set; }
}
