namespace IntelligentDiagnostician.BL.ResourceParameters;

public class ReadingResourceParameters : BaseResourceParameters
{
    public ReadingResourceParameters()
    {
        OrderBy = "CreatedDate desc";
    }
    // Filters
    public string? Severity { get; set; }
    public string? ProblemCode { get; set; }
}
