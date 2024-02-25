using System.ComponentModel.DataAnnotations;

namespace IntelligentDiagnostician.BL.DTOs.SensorDTOs;

public class SensorForUpdateDto
{
    [Required]
    [MinLength(3), MaxLength(20)]
    public string Name { get; set; } = string.Empty;
    public int CarSystemId { get; set; }
}