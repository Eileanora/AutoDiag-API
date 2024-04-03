namespace IntelligentDiagnostician.BL.DTOs.BaseDto;

public abstract class BaseDto
{
    public int? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public int? ModifiedBy { get; set; } 
    public DateTime? ModifiedDate { get; set; }
}
