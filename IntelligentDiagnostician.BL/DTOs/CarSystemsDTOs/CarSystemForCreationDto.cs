using System.ComponentModel.DataAnnotations;
using IntelligentDiagnostician.BL.DTOs.SensorDTOs;

namespace IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;

public class CarSystemForCreationDto : BaseDto.BaseDto
{
    public string CarSystemName { get; set; } = string.Empty;
    public ICollection<SensorForCreationDto>? Sensors { get; set; } = new List<SensorForCreationDto>();
}
;