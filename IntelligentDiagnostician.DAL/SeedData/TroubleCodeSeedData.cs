using IntelligentDiagnostician.DataModels.Models;

namespace IntelligentDiagnostician.DAL.SeedData
{
    public class TroubleCodeSeedData 
    {
        public static List<TroubleCode> LoadTroubleCode() => new List<TroubleCode>
        {
            new TroubleCode { ProblemCode = "P0079", ProblemDescription = "Exhaust Valve Control Circuit Low (Bank 2)", Severity = 4 },
            new TroubleCode { ProblemCode = "P2004", ProblemDescription = "Problem with the Intake Manifold Runner Control (IMRC) actuator, which controls the airflow into the engine", Severity = 6 },
            new TroubleCode { ProblemCode = "P3000", ProblemDescription = "Problem with the battery control system", Severity = 8 },
            new TroubleCode { ProblemCode = "P0078", ProblemDescription = "Exhaust Valve Control Circuit (Bank 2)", Severity = 3 },
            new TroubleCode { ProblemCode = "P007E", ProblemDescription = "Problem with the Charge Air Cooler Temperature Sensor Circuit", Severity = 5},
            new TroubleCode { ProblemCode = "P2036", ProblemDescription = "Problem with the Exhaust Gas Temperature Sensor Circuit", Severity = 4 },
            new TroubleCode { ProblemCode = "P007F", ProblemDescription = "Typically related to the fuel temperature sensor", Severity = 5 },
            new TroubleCode { ProblemCode = "P18E0", ProblemDescription = "Problem with the Fuel Pressure Sensor Circuit", Severity = 5 },
            new TroubleCode { ProblemCode = "P1004", ProblemDescription = "Problem with the Intake Valve Control Solenoid Circuit", Severity = 4 },
            new TroubleCode { ProblemCode = "P18D0", ProblemDescription = "Problem with the Exhaust Valve Control Solenoid Circuit", Severity = 4 },
            new TroubleCode { ProblemCode = "P18F0", ProblemDescription = "Problem with the Turbocharger Boost Control Solenoid Circuit", Severity = 5 },
            new TroubleCode { ProblemCode = "C1004", ProblemDescription = "Related to the Driver Knee Bolster Deployment Control", Severity = 5 },
            new TroubleCode { ProblemCode = "B0004", ProblemDescription = "Related to the Driver Knee Bolster Deployment Control", Severity = 4 },
            new TroubleCode { ProblemCode = "U1004", ProblemDescription = "Indicates an intermittent Controller Area Network Bus Transmit Performance", Severity = 8},
            new TroubleCode { ProblemCode = "p0000", ProblemDescription = "No Truble Code", Severity = 0}
        };
    }
   


}
