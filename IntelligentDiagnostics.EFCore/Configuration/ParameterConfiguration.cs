using IntelligentDiagnostics.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentDiagnostics.EFCore.Configuration
{
    public class ParameterConfiguration : IEntityTypeConfiguration<Parameter>
    {
        public void Configure(EntityTypeBuilder<Parameter> builder)
        {
            builder.HasKey(x => x.ParameterId);

            builder.Property(x => x.ParameterName)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnType("varchar");
        }

    }
}
