using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace IntelligentDiagnostics.Core.Models
{
    public class SystemCar
    {
        public int SystemCarId { get; set; }
        public string SystemCarName { get; set; }
        public ICollection<Reading> Readings { get; set; } = new List<Reading>();
    }
}
