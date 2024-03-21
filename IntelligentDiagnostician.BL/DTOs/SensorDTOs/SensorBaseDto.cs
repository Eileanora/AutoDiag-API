using System.ComponentModel.DataAnnotations;

namespace IntelligentDiagnostician.BL.DTOs.SensorDTOs;

public abstract class SensorBaseDto
{
    [Required(ErrorMessage = "Name should be filled in")]
    [MaxLength(10)]
    public string SensorName { get; set; } = string.Empty;
    public int CarSystemId { get; set; }
}
