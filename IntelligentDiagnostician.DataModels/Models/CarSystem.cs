namespace IntelligentDiagnostician.DataModels.Models;

public class CarSystem : BaseEntity
{
    public string CarSystemName { get; set; }
    public ICollection<Sensor>? Sensors { get; set; } = new List<Sensor>();
    public ICollection<Reading> Readings { get; set; } = new List<Reading>();
}
