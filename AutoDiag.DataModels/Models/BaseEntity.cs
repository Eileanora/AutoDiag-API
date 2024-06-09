namespace AutoDiag.DataModels.Models;

public abstract class BaseEntity : IAuditFields
{
    public Guid? CreatedBy { get; init; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public Guid? ModifiedBy { get; set; }
    public DateTime ModifiedDate { get; set; } = DateTime.Now;
}
