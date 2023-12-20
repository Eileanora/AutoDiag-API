using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentDiagnostics.DataModels.Models
{
    public class Reading
    {
        public int ReadingId { get; set; }
        public int ReadingValue { get; set;}
        public DateTime ReadingDateTime { get; set; }  
        public int SystemCarId { get; set; }    
        public SystemCar SystemCar { get; set; }    
        public int ParameterId { get; set; }    
        public Parameter Parameter { get; set; }    
        public int UserId { get; set; } 
        public User User { get; set; }    



        
    }
}
