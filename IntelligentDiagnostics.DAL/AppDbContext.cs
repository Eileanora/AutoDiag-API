using IntelligentDiagnostics.DataModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelligentDiagnostics.DAL.Configuration;

namespace IntelligentDiagnostics.DAL
{
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
        }
        DbSet<SystemCar> systemCars {  get; set; }    
        DbSet<User> users { get; set; }
        DbSet<Reading> readings { get; set; } 
        DbSet<Parameter> parameters { get; set; }
        DbSet<Error> errors { get; set; }
        


       


    }
}
