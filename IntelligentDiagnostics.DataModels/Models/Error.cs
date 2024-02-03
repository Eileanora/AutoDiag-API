namespace IntelligentDiagnostics.DataModels.Models;

public class Error : BaseEntity
{
    public string Description { get; set; }
    public int  UserId {  get; set; }   
    public User User { get; set; }  
}
