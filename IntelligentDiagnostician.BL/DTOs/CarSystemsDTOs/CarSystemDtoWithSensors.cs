using IntelligentDiagnostician.BL.DTOs.SensorDTOs;

namespace IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;

public class CarSystemDtoWithSensors
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public ICollection<string> SensorsNames { get; set; } = new List<string>();
}
