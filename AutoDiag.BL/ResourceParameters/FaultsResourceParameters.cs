namespace AutoDiag.BL.ResourceParameters;

public class FaultsResourceParameters : BaseResourceParameters
{
    public FaultsResourceParameters()
    {
        OrderBy = "CreatedDate desc";
    }
    // Filters
    public string? Severity { get; set; }
    public string? ProblemCode { get; set; }
}
