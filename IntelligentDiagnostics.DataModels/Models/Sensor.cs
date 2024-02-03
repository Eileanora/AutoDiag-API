namespace IntelligentDiagnostics.DataModels.Models;

public class Sensor : PrimaryKeyBaseEntity
{
    public string SensorName { get; set; }
    public ICollection<Reading> Readings { get; set; } = new List<Reading>();
}
