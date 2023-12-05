using IntelligentDiagnostics.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntelligentDiagnostics.EFCore.Configuration
{
    public class ErrorConfiguration : IEntityTypeConfiguration<Error>
    {
        public void Configure(EntityTypeBuilder<Error> builder)
        {
            builder.HasKey(x => x.ErrorId);

            builder.Property(x => x.Description)
                .HasColumnType("varchar")
                .IsRequired();

            builder.HasOne(x => x.User)
               .WithMany(x => x.errors)
               .HasForeignKey(x => x.UserId).IsRequired();

        }
    }


}


