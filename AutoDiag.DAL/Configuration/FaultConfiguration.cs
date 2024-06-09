using AutoDiag.DataModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoDiag.DAL.Configuration;

public class FaultConfiguration : IEntityTypeConfiguration<Fault>
{
    public void Configure(EntityTypeBuilder<Fault> builder)
    {
        // builder.HasKey(e => new { e.Id, e.CreatedDate });
        builder.Property(e => e.ProblemCode)
            .IsRequired()
            .HasMaxLength(5);
        
        builder.HasOne(e => e.TroubleCode)
            .WithMany()
            .HasForeignKey(e => e.ProblemCode);
        
        builder.HasOne(x => x.User)
            .WithMany(x => x.Errors)
            .HasForeignKey(x => x.UserId).IsRequired();
    }
}
