using AutoDiag.DAL.Configuration;
using AutoDiag.DataModels.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutoDiag.DAL.Context;

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
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FaultConfiguration).Assembly);
    }
    public DbSet<CarSystem> CarSystems {  get; set; }    
    public DbSet<Reading> Readings { get; set; } 
    public DbSet<Sensor> Sensors { get; set; }
    public DbSet<TroubleCode> TroubleCodes { get; set; }
    public DbSet<Fault> Faults { get; set; }
    public DbSet<TroubleCodeLink> TroubleCodeLinks { get; set; }
}
