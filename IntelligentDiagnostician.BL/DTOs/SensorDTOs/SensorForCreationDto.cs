using System.ComponentModel.DataAnnotations;
using IntelligentDiagnostician.BL.DTOs.BaseDTOs;

namespace IntelligentDiagnostician.BL.DTOs.SensorDTOs;

public class SensorForCreationDto : BaseDto
{
    [Required(ErrorMessage = "Name should be filled in")]
    [MaxLength(10)]
    public string SensorName { get; set; } = string.Empty;
    public int CarSystemId { get; set; }
}
