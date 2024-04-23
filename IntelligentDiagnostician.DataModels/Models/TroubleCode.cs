namespace IntelligentDiagnostician.DataModels.Models;

public class TroubleCode : BaseEntity
{
    public string ProblemCode { get; set; } = string.Empty;
    public string ProblemDescription { get; set; } = string.Empty;
    public string? Severity { get; set; }
}
