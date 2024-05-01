using IntelligentDiagnostician.DAL.SeedData;
using IntelligentDiagnostician.DataModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntelligentDiagnostician.DAL.Configuration;

public class TroubleCodeLinkConfiguration : IEntityTypeConfiguration<TroubleCodeLink>
{
    public void Configure(EntityTypeBuilder<TroubleCodeLink> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnType("varchar");
        
        builder.Property(x => x.Link)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnType("varchar");
        
        builder.Property(x => x.ProblemCode)
            .IsRequired()
            .HasMaxLength(5)
            .HasColumnType("varchar");
        
        builder.HasOne(x => x.TroubleCode)
            .WithMany(x => x.TroubleCodeLinks)
            .HasForeignKey(x => x.ProblemCode)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(TroubleCodeLinkSeedData.LoadTroubleCodeLink()); 
    }
}
