using IntelligentDiagnostician.DataModels.Models;

namespace IntelligentDiagnostician.DAL.SeedData
{
    public class SensorsSeedData 
    {
        public static List<Sensor> LoadSensor() => new List<Sensor>()
        {
            new Sensor { Id = 100, SensorName = "Engine Coolant Temperature", CarSystemId = 3, MinValue = 0.5f, MaxValue = 4.5f, AvgValue = 2.5f, Unit = "volts" },
            new Sensor { Id = 101, SensorName = "Fuel Level", CarSystemId = 4, MinValue = 0f, MaxValue = 5f, AvgValue = 2.5f, Unit = "volts" },
            new Sensor { Id = 102, SensorName = "Barometric Pressure", CarSystemId = 2, MinValue = 80f, MaxValue = 101.3f, AvgValue = 90.65f, Unit = "kPa" },
            new Sensor { Id = 103, SensorName = "Air in Tank Temperature", CarSystemId = 2, MinValue = -40f, MaxValue = 40f, AvgValue = 0f, Unit = "°C" },
            new Sensor { Id = 104, SensorName = "MAF (Mass Air Flow)", CarSystemId = 1, MinValue = 4f, MaxValue = 5f, AvgValue = 4.5f, Unit = "volts" },
            new Sensor { Id = 105, SensorName = "Intake Manifold Pressure", CarSystemId = 1, MinValue = 30f, MaxValue = 250f, AvgValue = 140f, Unit = "kPa" },
            new Sensor { Id = 106, SensorName = "Engine Power", CarSystemId = 1, MinValue = 37, MaxValue = 112, AvgValue = 75, Unit = "kW" },
            new Sensor { Id = 107, SensorName = "Engine Load", CarSystemId = 1, MinValue = 10, MaxValue = 100, AvgValue = 45, Unit = "%" }

        };
    }
   


}
