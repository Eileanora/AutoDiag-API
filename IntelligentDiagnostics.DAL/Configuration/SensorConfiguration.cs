using IntelligentDiagnostics.DataModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntelligentDiagnostics.DAL.Configuration;

public class SensorConfiguration : IEntityTypeConfiguration<Sensor>
{
    public void Configure(EntityTypeBuilder<Sensor> builder)
    {
        builder.Property(x => x.SensorName)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnType("varchar");
        builder.HasOne(x => x.CarSystem)
            .WithMany(x => x.Sensors)
            .HasForeignKey(x => x.CarSystemId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
