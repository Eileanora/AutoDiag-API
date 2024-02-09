namespace IntelligentDiagnostician.BL.DTOs.BaseDTOs;

public class BaseDto
{
    public int? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public int? ModifiedBy { get; set; } 
    public DateTime? ModifiedDate { get; set; }
}
