namespace IntelligentDiagnostician.BL.ResourceParameters;

public abstract class BaseResourceParameters
{
    public string? SearchQuery { get; set; }
    // filters
    public string? UserId { get; set; }
}