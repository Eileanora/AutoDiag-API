namespace IntelligentDiagnostician.DataModels.Models;

public class Error : BaseEntity
{
    public string Description { get; set; } = string.Empty;
    public AppUser User { get; set; }
}
