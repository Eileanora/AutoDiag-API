// using System.Collections.Immutable;
// using IntelligentDiagnostician.DataModels.Models;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
//
// namespace IntelligentDiagnostician.DAL.Configuration;
//
// public class PrimaryKeyBaseEntityConfiguration : IEntityTypeConfiguration<PrimaryKeyBaseEntity>
// {
//     public void Configure(EntityTypeBuilder<PrimaryKeyBaseEntity> builder)
//     {
//         builder.HasKey(x => x.Id);
//         builder.Property(x => x.Id).ValueGeneratedOnAdd();
//     }
// }
