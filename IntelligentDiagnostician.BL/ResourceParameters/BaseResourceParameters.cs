namespace IntelligentDiagnostician.BL.ResourceParameters;

public abstract class BaseResourceParameters
{
    public string? SearchQuery { get; set; }
    // filters
    public string? Name { get; set; }
    public string? UserId { get; set; }
}