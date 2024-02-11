using IntelligentDiagnostician.BL.DTOs.BaseDTOs;
using IntelligentDiagnostician.BL.DTOs.SensorDTOs;

namespace IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;

public class CarSystemDto : BaseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public IEnumerable<string>? Sensors { get; set; }
}
