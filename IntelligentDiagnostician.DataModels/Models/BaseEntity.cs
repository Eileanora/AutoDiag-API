namespace IntelligentDiagnostician.DataModels.Models;

public abstract class BaseEntity
{
    public int? CreatedBy { get; init; }
    public DateTime? CreatedDate { get; init; } = DateTime.UtcNow;
    public int? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; } = DateTime.UtcNow;
}
