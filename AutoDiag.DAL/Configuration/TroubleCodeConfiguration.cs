using AutoDiag.DAL.SeedData;
using AutoDiag.DataModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoDiag.DAL.Configuration;

public class TroubleCodeConfiguration : IEntityTypeConfiguration<TroubleCode>
{
    public void Configure(EntityTypeBuilder<TroubleCode> builder)
    {
        builder.HasKey(x => x.ProblemCode);
        
        builder.Property(x => x.ProblemCode)
            .IsRequired()
            .HasMaxLength(5)
            .HasColumnType("varchar")
            .ValueGeneratedNever();
        
        builder.Property(x => x.ProblemDescription)
            .IsRequired()
            .HasMaxLength(500)
            .HasColumnType("varchar");

        builder.HasData(TroubleCodeSeedData.LoadTroubleCode()); 
    }
}
