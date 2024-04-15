namespace IntelligentDiagnostician.DataModels.Models;

public abstract class BaseEntity : IAuditFields
{
    public int Id { get; set; }

    public int? CreatedBy { get; init; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public int ModifiedBy { get; set; }
    public DateTime ModifiedDate { get; set; } = DateTime.Now;
}
