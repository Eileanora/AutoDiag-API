using System.ComponentModel.DataAnnotations;
using IntelligentDiagnostician.BL.DTOs.SensorDTOs;

namespace IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;

public class CarSystemForCreationDto : CarSystemBaseDto
{
    public ICollection<SensorForCreationDto>? Sensors { get; set; } = new List<SensorForCreationDto>();
}
