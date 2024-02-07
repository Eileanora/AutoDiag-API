using IntelligentDiagnostics.BL.Dtos.SensorDTOs;

namespace IntelligentDiagnostics.BL.Dtos.CarSystemsDTOs;

public class CarSystemDtoWithSensors
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public int ModifiedBy { get; set; }
    public DateTime ModifiedDate { get; set; }
    public ICollection<SensorWithOnlyNameDto> Sensors { get; set; } = new List<SensorWithOnlyNameDto>();
}
