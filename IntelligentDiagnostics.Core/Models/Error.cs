using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentDiagnostics.Core.Models
{
    public class Error
    {
        public int ErrorId { get; set; }
        public string Description { get; set; }
        public DateTime ErrorDateTime { get; set; }
        public int  UserId {  get; set; }   
        public User User { get; set; }  


    }
}
