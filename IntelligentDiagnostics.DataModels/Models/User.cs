using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentDiagnostics.DataModels.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Reading> Readings { get; set; } = new List<Reading>();
        public ICollection<Error> errors { get; set; } = new List<Error>();

        
    }
}
