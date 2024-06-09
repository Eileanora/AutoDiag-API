namespace AutoDiag.DataModels.Models;

public class Fault : PrimaryKeyBaseEntity
{
    public string ProblemCode { get; set; } = string.Empty;
    public string UserId { get; set; }
    public TroubleCode TroubleCode { get; set; }
    public AppUser User { get; set; }
}
