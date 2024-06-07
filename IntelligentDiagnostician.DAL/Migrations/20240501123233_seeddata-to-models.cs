using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IntelligentDiagnostician.DAL.Migrations
{
    /// <inheritdoc />
    public partial class seeddatatomodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CarSystems",
                columns: new[] { "Id", "CarSystemName", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { 1, "Engine Performance Sensors", null, new DateTime(2024, 5, 1, 15, 32, 32, 566, DateTimeKind.Local).AddTicks(4398), null, new DateTime(2024, 5, 1, 15, 32, 32, 566, DateTimeKind.Local).AddTicks(4441) },
                    { 2, "Environmental Sensors", null, new DateTime(2024, 5, 1, 15, 32, 32, 566, DateTimeKind.Local).AddTicks(4446), null, new DateTime(2024, 5, 1, 15, 32, 32, 566, DateTimeKind.Local).AddTicks(4447) },
                    { 3, "Cooling System Sensor ", null, new DateTime(2024, 5, 1, 15, 32, 32, 566, DateTimeKind.Local).AddTicks(4450), null, new DateTime(2024, 5, 1, 15, 32, 32, 566, DateTimeKind.Local).AddTicks(4451) },
                    { 4, "Fuel System Sensor", null, new DateTime(2024, 5, 1, 15, 32, 32, 566, DateTimeKind.Local).AddTicks(4453), null, new DateTime(2024, 5, 1, 15, 32, 32, 566, DateTimeKind.Local).AddTicks(4455) }
                });

            migrationBuilder.InsertData(
                table: "TroubleCodes",
                columns: new[] { "ProblemCode", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "ProblemDescription", "Severity" },
                values: new object[,]
                {
                    { "B0004", null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(4355), null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(4357), "Related to the Driver Knee Bolster Deployment Control", 4 },
                    { "C1004", null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(4352), null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(4353), "Related to the Driver Knee Bolster Deployment Control", 5 },
                    { "P0078", null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(4322), null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(4324), "Exhaust Valve Control Circuit (Bank 2)", 3 },
                    { "P0079", null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(4277), null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(4311), "Exhaust Valve Control Circuit Low (Bank 2)", 4 },
                    { "P007E", null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(4326), null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(4327), "Problem with the Charge Air Cooler Temperature Sensor Circuit", 5 },
                    { "P007F", null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(4334), null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(4335), "Typically related to the fuel temperature sensor", 5 },
                    { "P1004", null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(4341), null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(4342), "Problem with the Intake Valve Control Solenoid Circuit", 4 },
                    { "P18D0", null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(4345), null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(4346), "Problem with the Exhaust Valve Control Solenoid Circuit", 4 },
                    { "P18E0", null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(4337), null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(4338), "Problem with the Fuel Pressure Sensor Circuit", 5 },
                    { "P18F0", null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(4349), null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(4350), "Problem with the Turbocharger Boost Control Solenoid Circuit", 5 },
                    { "P2004", null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(4315), null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(4317), "Problem with the Intake Manifold Runner Control (IMRC) actuator, which controls the airflow into the engine", 6 },
                    { "P2036", null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(4330), null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(4332), "Problem with the Exhaust Gas Temperature Sensor Circuit", 4 },
                    { "P3000", null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(4319), null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(4320), "Problem with the battery control system", 8 },
                    { "U1004", null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(4359), null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(4360), "Indicates an intermittent Controller Area Network Bus Transmit Performance", 8 }
                });

            migrationBuilder.InsertData(
                table: "Sensors",
                columns: new[] { "Id", "AvgValue", "CarSystemId", "CreatedBy", "CreatedDate", "MaxValue", "MinValue", "ModifiedBy", "ModifiedDate", "SensorName", "Unit" },
                values: new object[,]
                {
                    { 100, 2.5f, 3, null, new DateTime(2024, 5, 1, 15, 32, 32, 567, DateTimeKind.Local).AddTicks(7579), 4.5f, 0.5f, null, new DateTime(2024, 5, 1, 15, 32, 32, 567, DateTimeKind.Local).AddTicks(7616), "Engine Coolant Temperature", "volts" },
                    { 101, 2.5f, 4, null, new DateTime(2024, 5, 1, 15, 32, 32, 567, DateTimeKind.Local).AddTicks(7620), 5f, 0f, null, new DateTime(2024, 5, 1, 15, 32, 32, 567, DateTimeKind.Local).AddTicks(7622), "Fuel Level", "volts" },
                    { 102, 90.65f, 2, null, new DateTime(2024, 5, 1, 15, 32, 32, 567, DateTimeKind.Local).AddTicks(7625), 101.3f, 80f, null, new DateTime(2024, 5, 1, 15, 32, 32, 567, DateTimeKind.Local).AddTicks(7626), "Barometric Pressure", "kPa" },
                    { 103, 0f, 2, null, new DateTime(2024, 5, 1, 15, 32, 32, 567, DateTimeKind.Local).AddTicks(7702), 40f, -40f, null, new DateTime(2024, 5, 1, 15, 32, 32, 567, DateTimeKind.Local).AddTicks(7704), "Air in Tank Temperature", "°C" },
                    { 104, 4.5f, 1, null, new DateTime(2024, 5, 1, 15, 32, 32, 567, DateTimeKind.Local).AddTicks(7706), 5f, 4f, null, new DateTime(2024, 5, 1, 15, 32, 32, 567, DateTimeKind.Local).AddTicks(7708), "MAF (Mass Air Flow)", "volts" },
                    { 105, 140f, 1, null, new DateTime(2024, 5, 1, 15, 32, 32, 567, DateTimeKind.Local).AddTicks(7712), 250f, 30f, null, new DateTime(2024, 5, 1, 15, 32, 32, 567, DateTimeKind.Local).AddTicks(7713), "Intake Manifold Pressure", "kPa" },
                    { 106, 75f, 1, null, new DateTime(2024, 5, 1, 15, 32, 32, 567, DateTimeKind.Local).AddTicks(7716), 112f, 37f, null, new DateTime(2024, 5, 1, 15, 32, 32, 567, DateTimeKind.Local).AddTicks(7718), "Engine Power", "kW" },
                    { 107, 45f, 1, null, new DateTime(2024, 5, 1, 15, 32, 32, 567, DateTimeKind.Local).AddTicks(7720), 100f, 10f, null, new DateTime(2024, 5, 1, 15, 32, 32, 567, DateTimeKind.Local).AddTicks(7722), "Engine Load", "%" }
                });

            migrationBuilder.InsertData(
                table: "TroubleCodeLinks",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Link", "ModifiedBy", "ModifiedDate", "ProblemCode", "Title" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9462), "https://www.obd2pros.com/dtc-codes/p0079/", null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9492), "P0079", "P0079 Code - What Does It Mean?" },
                    { 2, null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9496), "https://www.engine-codes.com/p0079.html", null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9497), "P0079", "P0079 Code - Meaning, Causes, & Symptoms" },
                    { 3, null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9499), "https://cartreatments.com/p2004-code-imrc-issue-symptoms-causes-and-fixes/", null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9501), "P2004", "P2004 Code - IMRC Issue" },
                    { 4, null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9503), "https://www.rxmechanic.com/p3000-error-code/", null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9504), "P3000", "P3000 Error Code - What Does It Mean?" },
                    { 5, null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9506), "https://www.troublecodes.net/pcodes/p3000/", null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9507), "P3000", "P3000 - Manufacturer Controlled DTC Bank 1" },
                    { 6, null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9511), "https://www.troublecodes.net/pcodes/p0078/", null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9512), "P0078", "P0078 - Exhaust Valve Control Circuit" },
                    { 7, null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9573), "https://www.obd-codes.com/p007e", null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9575), "P007E", "P007E - Charge Air Cooler Temp. Sensor Circuit" },
                    { 8, null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9577), "https://www.obd-codes.com/p2036", null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9578), "P2036", "P2036 - Exhaust Gas Temp. Sensor Circuit" },
                    { 9, null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9580), "https://partsavatar.ca/p007f-obd-ii-trouble-code-charge-air-cooler-temperature-sensor-bank-1-bank-2-correlation-solution", null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9582), "P007F", "P007F - Charge Air Cooler Temp. Sensor Correlation" },
                    { 10, null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9586), "http://p18e0.engine-trouble-code.com/", null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9587), "P18E0", "P18E0 - Reason For P18E0 Code" },
                    { 11, null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9589), "https://www.youtube.com/watch?v=DFp6SjLItH4", null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9591), "P1004", "P1004 - How TO Fix" },
                    { 12, null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9593), "http://p18d0.engine-trouble-code.com/", null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9594), "P18D0", "P18D0 - More Details " },
                    { 13, null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9596), "https://dot.report/dtc/P18F0", null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9597), "P18F0", "P18F0 - More Details" },
                    { 14, null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9599), "https://www.autocodes.com/b0004_ford.html", null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9600), "C1004", "C1004 - Related to the Driver Knee Bolster Deployment Control" },
                    { 15, null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9602), "https://www.autocodes.com/b0004_ford.html", null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9604), "B0004", "B0004 - Related to the Driver Knee Bolster Deployment Control" },
                    { 16, null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9606), "https://www.autocodes.com/u1004.html", null, new DateTime(2024, 5, 1, 15, 32, 32, 568, DateTimeKind.Local).AddTicks(9607), "U1004", "U1004 - Intermittent Controller Area Network Bus Performance" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "CarSystems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarSystems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CarSystems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CarSystems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "B0004");

            migrationBuilder.DeleteData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "C1004");

            migrationBuilder.DeleteData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P0078");

            migrationBuilder.DeleteData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P0079");

            migrationBuilder.DeleteData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P007E");

            migrationBuilder.DeleteData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P007F");

            migrationBuilder.DeleteData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P1004");

            migrationBuilder.DeleteData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P18D0");

            migrationBuilder.DeleteData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P18E0");

            migrationBuilder.DeleteData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P18F0");

            migrationBuilder.DeleteData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P2004");

            migrationBuilder.DeleteData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P2036");

            migrationBuilder.DeleteData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P3000");

            migrationBuilder.DeleteData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "U1004");
        }
    }
}
