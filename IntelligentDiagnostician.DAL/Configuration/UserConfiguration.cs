//using IntelligentDiagnostician.DataModels.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace IntelligentDiagnostician.DAL.Configuration
//{
//    public class UserConfiguration : IEntityTypeConfiguration<AppUser>
//    {
//        public void Configure(EntityTypeBuilder<AppUser> builder)
//        {
//            builder.Property(x => x.FirstName).IsRequired()
//                   .HasMaxLength(20)
//                   .IsUnicode(false)
//                   .HasAnnotation("RegularExpression", new RegularExpressionAttribute(@"^[A-Z]+[a-zA-Z]*$")
//                   { ErrorMessage = "First Name must contain only letters and start with a capital letter" });
            
//            builder.Property(x =>x.LastName)
//                .IsRequired()
//                .IsUnicode(false)
//                .HasAnnotation("RegularExpression", new RegularExpressionAttribute(@"^[A-Z]+[a-zA-Z]*$")
//                { ErrorMessage = "First Name must contain only letters and start with a capital letter" });



//        }
//    }
//}
