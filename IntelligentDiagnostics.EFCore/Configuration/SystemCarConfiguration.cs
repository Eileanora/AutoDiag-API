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
    public class SystemCarConfiguration : IEntityTypeConfiguration<SystemCar>
    {
        public void Configure(EntityTypeBuilder<SystemCar> builder)
        {
            builder.HasKey(x => x.SystemCarId);

            builder.Property(x=> x.SystemCarName)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnType("varchar"); 
        }
    }


}


