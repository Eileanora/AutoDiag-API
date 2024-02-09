namespace IntelligentDiagnostician.BL.Dtos;

public class BaseDto
{
    public int? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public int? ModifiedBy { get; set; } 
    public DateTime? ModifiedDate { get; set; }
}
