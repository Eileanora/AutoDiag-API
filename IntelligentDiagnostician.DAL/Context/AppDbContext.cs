using IntelligentDiagnostician.DAL.Configuration;
using IntelligentDiagnostician.DataModels.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IntelligentDiagnostician.DAL.Context;

public class AppDbContext : IdentityDbContext<AppUser>
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
    }
    public DbSet<CarSystem> CarSystems {  get; set; }    
    public DbSet<Reading> Readings { get; set; } 
    public DbSet<Sensor> Sensors { get; set; }
    public DbSet<TroubleCode> TroubleCodes { get; set; }
    public DbSet<Error> Errors { get; set; }
    public DbSet<TroubleCodeLink> TroubleCodeLinks { get; set; }
}
