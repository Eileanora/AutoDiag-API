namespace IntelligentDiagnostician.DataModels.Models;

public interface IAuditFields
{
    public int? CreatedBy { get; init; }
    public DateTime CreatedDate { get; set; }
    public int ModifiedBy { get; set; }
    public DateTime ModifiedDate { get; set; }
}