namespace IntelligentDiagnostician.DataModels.Models;

public class Role : PrimaryKeyBaseEntity
{
    public string RoleName { get; set; }
    public ICollection<User> Users { get; set; }
}
