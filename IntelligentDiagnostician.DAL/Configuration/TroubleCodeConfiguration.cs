using IntelligentDiagnostician.DataModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntelligentDiagnostician.DAL.Configuration;

public class TroubleCodeConfiguration : IEntityTypeConfiguration<TroubleCode>
{
    public void Configure(EntityTypeBuilder<TroubleCode> builder)
    {
        builder.HasKey(x => x.Code);
        
        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(10)
            .HasColumnType("varchar")
            .ValueGeneratedNever();
        
        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnType("varchar");
        
        builder.Property(x => x.Severity)
            .HasMaxLength(10)
            .HasColumnType("varchar");
    }
}
