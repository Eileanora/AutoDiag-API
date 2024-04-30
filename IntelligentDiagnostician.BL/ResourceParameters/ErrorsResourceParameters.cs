namespace IntelligentDiagnostician.BL.ResourceParameters;

public class ErrorsResourceParameters : BaseResourceParameters
{
    public ErrorsResourceParameters()
    {
        OrderBy = "CreatedDate desc";
    }
    // Filters
    public string? Severity { get; set; }
    public string? ProblemCode { get; set; }
}
