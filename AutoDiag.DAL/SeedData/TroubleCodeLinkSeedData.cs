using AutoDiag.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDiag.DAL.SeedData
{
    public class TroubleCodeLinkSeedData 
    {
        public static List<TroubleCodeLink> LoadTroubleCodeLink() => new List<TroubleCodeLink>
        {
            new TroubleCodeLink { Id = 1, ProblemCode = "P0079", Title = "P0079 Code - What Does It Mean?", Link = "https://www.obd2pros.com/dtc-codes/p0079/" },
            new TroubleCodeLink { Id = 2, ProblemCode = "P0079", Title = "P0079 Code - Meaning, Causes, & Symptoms", Link = "https://www.engine-codes.com/p0079.html" },

            new TroubleCodeLink { Id = 3, ProblemCode = "P2004", Title = "P2004 Code - IMRC Issue", Link = "https://cartreatments.com/p2004-code-imrc-issue-symptoms-causes-and-fixes/" },

            new TroubleCodeLink { Id = 4, ProblemCode = "P3000", Title = "P3000 Error Code - What Does It Mean?", Link = "https://www.rxmechanic.com/p3000-error-code/" },
            new TroubleCodeLink { Id = 5, ProblemCode = "P3000", Title = "P3000 - Manufacturer Controlled DTC Bank 1", Link = "https://www.troublecodes.net/pcodes/p3000/" },

            new TroubleCodeLink { Id = 6, ProblemCode = "P0078", Title = "P0078 - Exhaust Valve Control Circuit", Link = "https://www.troublecodes.net/pcodes/p0078/" },

            new TroubleCodeLink { Id = 7, ProblemCode = "P007E", Title = "P007E - Charge Air Cooler Temp. Sensor Circuit", Link = "https://www.obd-codes.com/p007e" },

            new TroubleCodeLink { Id = 8, ProblemCode = "P2036", Title = "P2036 - Exhaust Gas Temp. Sensor Circuit", Link = "https://www.obd-codes.com/p2036" },

            new TroubleCodeLink { Id = 9, ProblemCode = "P007F", Title = "P007F - Charge Air Cooler Temp. Sensor Correlation", Link = "https://partsavatar.ca/p007f-obd-ii-trouble-code-charge-air-cooler-temperature-sensor-bank-1-bank-2-correlation-solution" },

            new TroubleCodeLink { Id = 10, ProblemCode = "P18E0", Title = "P18E0 - Reason For P18E0 Code", Link = "http://p18e0.engine-trouble-code.com/" },

            new TroubleCodeLink { Id = 11, ProblemCode = "P1004", Title = "P1004 - How TO Fix", Link = "https://www.youtube.com/watch?v=DFp6SjLItH4" },

            new TroubleCodeLink { Id = 12, ProblemCode = "P18D0", Title = "P18D0 - More Details ", Link = "http://p18d0.engine-trouble-code.com/" },

            new TroubleCodeLink { Id = 13, ProblemCode = "P18F0", Title = "P18F0 - More Details", Link = "https://dot.report/dtc/P18F0" },

            new TroubleCodeLink { Id = 14, ProblemCode = "C1004", Title = "C1004 - Related to the Driver Knee Bolster Deployment Control", Link = "https://www.autocodes.com/b0004_ford.html" },

            new TroubleCodeLink { Id = 15, ProblemCode = "B0004", Title = "B0004 - Related to the Driver Knee Bolster Deployment Control", Link = "https://www.autocodes.com/b0004_ford.html" },

            new TroubleCodeLink { Id = 16, ProblemCode = "U1004", Title = "U1004 - Intermittent Controller Area Network Bus Performance", Link = "https://www.autocodes.com/u1004.html" }
        };
    }
   


}
