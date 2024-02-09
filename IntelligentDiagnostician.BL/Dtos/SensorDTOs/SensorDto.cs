using System.Runtime.InteropServices.JavaScript;

namespace IntelligentDiagnostician.BL.Dtos.SensorDTOs;

public class SensorDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CarSystemName { get; set; } = string.Empty;

}
