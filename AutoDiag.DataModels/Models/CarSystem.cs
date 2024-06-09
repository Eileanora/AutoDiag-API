namespace AutoDiag.DataModels.Models;

public class CarSystem : PrimaryKeyBaseEntity
{
    public string CarSystemName { get; set; }
    public ICollection<Sensor>? Sensors { get; set; } = new List<Sensor>();
}
