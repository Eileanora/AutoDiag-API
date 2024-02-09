using IntelligentDiagnostician.BL.Dtos.SensorDTOs;

namespace IntelligentDiagnostician.BL.Dtos.CarSystemsDTOs;

public class CarSystemDtoWithSensors
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public ICollection<string> SensorsNames { get; set; } = new List<string>();
}
