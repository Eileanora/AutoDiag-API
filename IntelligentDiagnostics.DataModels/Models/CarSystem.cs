namespace IntelligentDiagnostics.DataModels.Models;

public class CarSystem : PrimaryKeyBaseEntity
{
    public string CarSystemName { get; set; }
    public ICollection<Reading> Readings { get; set; } = new List<Reading>();
}
