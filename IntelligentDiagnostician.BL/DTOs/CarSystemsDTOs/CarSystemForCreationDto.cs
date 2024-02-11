using System.ComponentModel.DataAnnotations;

namespace IntelligentDiagnostician.BL.DTOs.CarSystemsDTOs;

public class CarSystemForCreationDto
{
    [Required(ErrorMessage = "Name should be filled in")]
    [MaxLength(10)]
    public string Name { get; set; } = string.Empty;
}
