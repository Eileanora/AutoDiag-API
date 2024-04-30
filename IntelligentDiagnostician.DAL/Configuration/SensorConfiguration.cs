using IntelligentDiagnostician.DAL.SeedData;
using IntelligentDiagnostician.DataModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntelligentDiagnostician.DAL.Configuration;

public class SensorConfiguration : IEntityTypeConfiguration<Sensor>
{
    public void Configure(EntityTypeBuilder<Sensor> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedNever();
        
        builder.Property(x => x.SensorName)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnType("varchar");
        
        builder.HasOne(x => x.CarSystem)
            .WithMany(x => x.Sensors)
            .HasForeignKey(x => x.CarSystemId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.Unit)
            .HasColumnType("varchar")
            .HasMaxLength(10);

        builder.HasData(SensorsSeedData.LoadSensor()); 
    }
}
