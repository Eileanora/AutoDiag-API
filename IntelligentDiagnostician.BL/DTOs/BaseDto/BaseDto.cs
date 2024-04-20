namespace IntelligentDiagnostician.BL.DTOs.BaseDto;

public abstract class BaseDto
{
    public Guid? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public Guid? ModifiedBy { get; set; } 
    public DateTime? ModifiedDate { get; set; }
}
