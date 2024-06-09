using IntelligentDiagnostician.DataModels.Models;

namespace IntelligentDiagnostician.DAL.SeedData
{
    public class SensorsSeedData 
    {
        public static List<Sensor> LoadSensor() => new List<Sensor>()
        {
            new Sensor { Id = 100, SensorName = "Engine Coolant Temperature", CarSystemId = 3, MinValue = 44f, MaxValue = 99f, AvgValue = 71.5f, Unit = "°C" },
            new Sensor { Id = 101, SensorName = "Throttle Position", CarSystemId = 4, MinValue = 13.3f, MaxValue = 47.8f, AvgValue = 30.5f, Unit = "%" },
            new Sensor { Id = 102, SensorName = "Timing Advance", CarSystemId = 2, MinValue = 36.5f, MaxValue = 64.9f, AvgValue = 55.7f, Unit = "%" },
            new Sensor { Id = 103, SensorName = "Air in Tank Temperature", CarSystemId = 2, MinValue = 28f, MaxValue = 51f, AvgValue = 39.5f, Unit = "°C" },
            new Sensor { Id = 104, SensorName = "Engine Rpm ", CarSystemId = 1, MinValue = 700f, MaxValue = 3125f, AvgValue = 1913f, Unit = "RPM" },
            new Sensor { Id = 105, SensorName = "Intake Manifold Pressure", CarSystemId = 1, MinValue = 26f, MaxValue = 101f, AvgValue = 63.5f, Unit = "kPa" },
            new Sensor { Id = 106, SensorName = "Engine Power", CarSystemId = 1, MinValue = 0f, MaxValue = 2.8f, AvgValue = 1.4f, Unit = "kW" },
            new Sensor { Id = 107, SensorName = "Engine Load", CarSystemId = 1, MinValue = 18f, MaxValue = 96.9f, AvgValue = 57.45f, Unit = "%" }

        };
    }
   


}
