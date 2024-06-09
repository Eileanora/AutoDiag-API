using AutoDiag.DataModels.Models;

namespace AutoDiag.DAL.SeedData
{
    public class CarSystemSeedData 
    {
        public static List<CarSystem> LoadCarSystems() => new()
        {
            new CarSystem {Id = 1 , CarSystemName = "Engine Performance Sensors" } ,
            new CarSystem {Id = 2 , CarSystemName = "Environmental Sensors"} ,
            new CarSystem {Id = 3 , CarSystemName = "Cooling System Sensor "} ,
            new CarSystem {Id = 4 , CarSystemName = "Fuel System Sensor"} ,
        };
    }




}
