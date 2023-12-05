using IntelligentDiagnostics.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntelligentDiagnostics.EFCore.Configuration
{
    public class ReadingConfiguration : IEntityTypeConfiguration<Reading>
    {
        public void Configure(EntityTypeBuilder<Reading> builder)
        {
            builder.HasKey(x => x.ReadingId);

            builder.Property(x => x.ReadingValue)
                   .IsRequired();

           builder.HasOne(x => x.SystemCar)
               .WithMany(x => x.Readings)
               .HasForeignKey(x => x.SystemCarId).IsRequired();

            builder.HasOne(x => x.Parameter)
               .WithMany(x => x.Readings)
               .HasForeignKey(x => x.ParameterId).IsRequired();

            builder.HasOne(x => x.User)
               .WithMany(x => x.Readings)
               .HasForeignKey(x => x.UserId).IsRequired();
        }
    }


}


