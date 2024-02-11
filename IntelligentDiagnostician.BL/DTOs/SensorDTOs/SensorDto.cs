using IntelligentDiagnostician.BL.DTOs.BaseDTOs;
namespace IntelligentDiagnostician.BL.DTOs.SensorDTOs;

public class SensorDto : BaseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int? CarSystemId { get; set; }
    public string? CarSystemName { get; set; }
}
