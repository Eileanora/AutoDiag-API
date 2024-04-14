using System.ComponentModel.DataAnnotations;

namespace IntelligentDiagnostician.BL.DTOs.SensorDTOs;

public class SensorForCreationDto : BaseDto.BaseDto
{
    public string SensorName { get; set; } = string.Empty;
    public int CarSystemId { get; set; }
}
