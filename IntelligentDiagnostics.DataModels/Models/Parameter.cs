using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentDiagnostics.DataModels.Models
{
    public class Parameter
    {
        public int ParameterId { get; set; }
        public string ParameterName { get; set; }
        public ICollection<Reading> Readings { get; set; } = new List<Reading>();

    }
}
