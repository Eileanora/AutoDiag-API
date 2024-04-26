using IntelligentDiagnostician.DataModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntelligentDiagnostician.DAL.Configuration;

public class ReadingConfiguration : IEntityTypeConfiguration<Reading>
{
    public void Configure(EntityTypeBuilder<Reading> builder)
    {
        builder.Property(x => x.Value)
               .IsRequired();

        builder.HasOne(x => x.Sensor)
           .WithMany(x => x.Readings)
           .HasForeignKey(x => x.SensorId).IsRequired()
           .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.User)
            .WithMany(x => x.Readings)
            .HasForeignKey(x => x.UserId).IsRequired();
        
        builder.HasOne(x => x.TroubleCode)
            .WithOne()
            .HasForeignKey<Reading>(x => x.Code)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.Property(x => x.Code)
            .HasMaxLength(10)
            .HasColumnType("varchar");
    }
}
