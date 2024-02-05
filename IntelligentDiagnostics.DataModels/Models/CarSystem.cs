namespace IntelligentDiagnostics.DataModels.Models;

public class CarSystem : PrimaryKeyBaseEntity
{
    public string CarSystemName { get; set; }
    public ICollection<Sensor> Sensors { get; set; } = new List<Sensor>();
    public ICollection<Reading> Readings { get; set; } = new List<Reading>();
}
