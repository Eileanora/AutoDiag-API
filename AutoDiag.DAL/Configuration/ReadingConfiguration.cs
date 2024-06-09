using AutoDiag.DataModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoDiag.DAL.Configuration;

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
    }
}
