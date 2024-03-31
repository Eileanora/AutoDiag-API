using System.ComponentModel.DataAnnotations;

namespace IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;

public abstract class CarSystemBaseDto
{
    [Required(ErrorMessage = "Name should be filled in")]
    [MaxLength(50, ErrorMessage = "Car system name must be less than 50 characters")]
    [MinLength(5, ErrorMessage = "Car system name must be more than 5 characters")]
    public string CarSystemName { get; set; } = string.Empty;
}
