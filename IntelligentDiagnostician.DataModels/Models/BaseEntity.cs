namespace IntelligentDiagnostician.DataModels.Models;

public abstract class BaseEntity : IAuditFields
{
    public int Id { get; set; }

    public Guid? CreatedBy { get; init; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public Guid? ModifiedBy { get; set; }
    public DateTime ModifiedDate { get; set; } = DateTime.Now;
}
