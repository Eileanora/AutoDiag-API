﻿namespace IntelligentDiagnostician.DataModels.Models;

public class Sensor : PrimaryKeyBaseEntity
{
    public string SensorName { get; set; }
    public int CarSystemId { get; set; }
    public CarSystem CarSystem { get; set; }
    public ICollection<Reading> Readings { get; set; } = new List<Reading>();
}
