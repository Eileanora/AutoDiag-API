namespace IntelligentDiagnostician.DataModels.Models;

public class Sensor : PrimaryKeyBaseEntity
{
    public string SensorName { get; set; }
    public int? CarSystemId { get; set; }
    public float? MinValue { get; set; }
    public float? MaxValue { get; set; }
    public float? AvgValue { get; set; }
    public string? Unit { get; set; }
    public CarSystem? CarSystem { get; set; }
    public ICollection<Reading>? Readings { get; set; } = new List<Reading>();
}
