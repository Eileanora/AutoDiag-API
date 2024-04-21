namespace IntelligentDiagnostician.DataModels.Models;

public class TroubleCode : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? Severity { get; set; }
}
