using IntelligentDiagnostics.DataModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntelligentDiagnostics.DAL.Configuration;

public class ErrorConfiguration : IEntityTypeConfiguration<Error>
{
    public void Configure(EntityTypeBuilder<Error> builder)
    {
        builder.Property(x => x.Description)
            .HasColumnType("varchar")
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithMany(x => x.Errors)
            .HasForeignKey(x => x.UserId).IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
