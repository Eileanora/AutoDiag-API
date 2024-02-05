using System.Runtime.InteropServices.JavaScript;

namespace IntelligentDiagnostics.BL.Dtos.SensorDTOs;

public class SensorDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string ModifiedBy { get; set; }
    public DateTime ModifiedDate { get; set; }
}
