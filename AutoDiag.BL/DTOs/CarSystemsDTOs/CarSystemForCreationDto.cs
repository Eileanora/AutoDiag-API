using System.ComponentModel.DataAnnotations;
using AutoDiag.BL.DTOs.SensorDTOs;

namespace AutoDiag.BL.DTOs.CarSystemsDTOs;

public class CarSystemForCreationDto
{
    public string CarSystemName { get; set; } = string.Empty;
    public ICollection<SensorForCreationDto>? Sensors { get; set; } = new List<SensorForCreationDto>();
}
;