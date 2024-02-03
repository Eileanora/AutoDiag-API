using System.Collections.Immutable;
using IntelligentDiagnostics.DataModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntelligentDiagnostics.DAL.Configuration;

public class PrimaryKeyBaseEntityConfiguration : IEntityTypeConfiguration<PrimaryKeyBaseEntity>
{
    public void Configure(EntityTypeBuilder<PrimaryKeyBaseEntity> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
