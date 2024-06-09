using AutoDiag.DAL.SeedData;
using AutoDiag.DataModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoDiag.DAL.Configuration;

public class CarSystemConfiguration : IEntityTypeConfiguration<CarSystem>
{
    public void Configure(EntityTypeBuilder<CarSystem> builder)
    {
        builder.Property(x=> x.CarSystemName)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnType("varchar");

        builder.HasData(CarSystemSeedData.LoadCarSystems()); 
    }
}
