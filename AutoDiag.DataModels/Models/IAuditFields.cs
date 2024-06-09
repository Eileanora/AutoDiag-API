namespace AutoDiag.DataModels.Models;

public interface IAuditFields
{
    public Guid? CreatedBy { get; init; }
    public DateTime CreatedDate { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime ModifiedDate { get; set; }
}