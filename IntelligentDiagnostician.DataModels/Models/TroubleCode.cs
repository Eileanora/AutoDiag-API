namespace IntelligentDiagnostician.DataModels.Models;

public class TroubleCode : BaseEntity
{
    public string ProblemCode { get; set; } = string.Empty;
    public string ProblemDescription { get; set; } = string.Empty;
    public ICollection<TroubleCodeLink>? TroubleCodeLinks { get; set; } = new List<TroubleCodeLink>();
    public int? Severity { get; set; }
}
