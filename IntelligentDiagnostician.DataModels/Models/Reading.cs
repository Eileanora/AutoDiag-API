namespace IntelligentDiagnostician.DataModels.Models;
public class Reading : BaseEntity
{
    public int Value { get; set;}
    public int SensorId { get; set; }
    public string UserId { get; set; }
    public Sensor Sensor { get; set; }
     
    public AppUser User { get; set; }
}
