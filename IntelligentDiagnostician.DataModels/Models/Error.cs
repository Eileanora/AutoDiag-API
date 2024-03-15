namespace IntelligentDiagnostician.DataModels.Models;

public class Error : PrimaryKeyBaseEntity
{
    public string Description { get; set; } = string.Empty;
    public int  UserId {  get; set; }   
    public AppUser User { get; set; }
}
