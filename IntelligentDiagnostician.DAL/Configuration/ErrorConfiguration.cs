using IntelligentDiagnostician.DataModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntelligentDiagnostician.DAL.Configuration;

public class ErrorConfiguration : IEntityTypeConfiguration<Error>
{
    public void Configure(EntityTypeBuilder<Error> builder)
    {
        builder.Property(x => x.Description)
            .HasColumnType("varchar")
            .IsRequired();

    }
}
