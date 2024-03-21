namespace IntelligentDiagnostician.BL.DTOs.Auditable;

public interface IAuditable
{
    public int? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public int? ModifiedBy { get; set; } 
    public DateTime? ModifiedDate { get; set; }
}
