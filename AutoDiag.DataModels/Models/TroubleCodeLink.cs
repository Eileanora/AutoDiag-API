namespace AutoDiag.DataModels.Models;

public class TroubleCodeLink : PrimaryKeyBaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    public string ProblemCode { get; set; } = string.Empty;
    public TroubleCode TroubleCode { get; set; }
}
