using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntelligentDiagnostician.DAL.Migrations
{
    /// <inheritdoc />
    public partial class newseedingdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CarSystems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 562, DateTimeKind.Local).AddTicks(6662), new DateTime(2024, 6, 3, 0, 31, 8, 562, DateTimeKind.Local).AddTicks(6702) });

            migrationBuilder.UpdateData(
                table: "CarSystems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 562, DateTimeKind.Local).AddTicks(6755), new DateTime(2024, 6, 3, 0, 31, 8, 562, DateTimeKind.Local).AddTicks(6757) });

            migrationBuilder.UpdateData(
                table: "CarSystems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 562, DateTimeKind.Local).AddTicks(6759), new DateTime(2024, 6, 3, 0, 31, 8, 562, DateTimeKind.Local).AddTicks(6760) });

            migrationBuilder.UpdateData(
                table: "CarSystems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 562, DateTimeKind.Local).AddTicks(6763), new DateTime(2024, 6, 3, 0, 31, 8, 562, DateTimeKind.Local).AddTicks(6764) });

            migrationBuilder.UpdateData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "AvgValue", "CreatedDate", "MaxValue", "MinValue", "ModifiedDate", "Unit" },
                values: new object[] { 71.5f, new DateTime(2024, 6, 3, 0, 31, 8, 563, DateTimeKind.Local).AddTicks(9915), 99f, 44f, new DateTime(2024, 6, 3, 0, 31, 8, 563, DateTimeKind.Local).AddTicks(9954), "°C" });

            migrationBuilder.UpdateData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "AvgValue", "CreatedDate", "MaxValue", "MinValue", "ModifiedDate", "SensorName", "Unit" },
                values: new object[] { 30.5f, new DateTime(2024, 6, 3, 0, 31, 8, 563, DateTimeKind.Local).AddTicks(9959), 47.8f, 13.3f, new DateTime(2024, 6, 3, 0, 31, 8, 563, DateTimeKind.Local).AddTicks(9960), "Throttle Position", "%" });

            migrationBuilder.UpdateData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "AvgValue", "CreatedDate", "MaxValue", "MinValue", "ModifiedDate", "SensorName", "Unit" },
                values: new object[] { 55.7f, new DateTime(2024, 6, 3, 0, 31, 8, 563, DateTimeKind.Local).AddTicks(9963), 64.9f, 36.5f, new DateTime(2024, 6, 3, 0, 31, 8, 563, DateTimeKind.Local).AddTicks(9965), "Timing Advance", "%" });

            migrationBuilder.UpdateData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "AvgValue", "CreatedDate", "MaxValue", "MinValue", "ModifiedDate" },
                values: new object[] { 39.5f, new DateTime(2024, 6, 3, 0, 31, 8, 563, DateTimeKind.Local).AddTicks(9967), 51f, 28f, new DateTime(2024, 6, 3, 0, 31, 8, 563, DateTimeKind.Local).AddTicks(9969) });

            migrationBuilder.UpdateData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "AvgValue", "CreatedDate", "MaxValue", "MinValue", "ModifiedDate", "SensorName", "Unit" },
                values: new object[] { 1913f, new DateTime(2024, 6, 3, 0, 31, 8, 563, DateTimeKind.Local).AddTicks(9972), 3125f, 700f, new DateTime(2024, 6, 3, 0, 31, 8, 563, DateTimeKind.Local).AddTicks(9973), "Engine Rpm ", "RPM" });

            migrationBuilder.UpdateData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "AvgValue", "CreatedDate", "MaxValue", "MinValue", "ModifiedDate" },
                values: new object[] { 63.5f, new DateTime(2024, 6, 3, 0, 31, 8, 563, DateTimeKind.Local).AddTicks(9977), 101f, 26f, new DateTime(2024, 6, 3, 0, 31, 8, 563, DateTimeKind.Local).AddTicks(9978) });

            migrationBuilder.UpdateData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "AvgValue", "CreatedDate", "MaxValue", "MinValue", "ModifiedDate" },
                values: new object[] { 1.4f, new DateTime(2024, 6, 3, 0, 31, 8, 563, DateTimeKind.Local).AddTicks(9981), 2.8f, 0f, new DateTime(2024, 6, 3, 0, 31, 8, 563, DateTimeKind.Local).AddTicks(9982) });

            migrationBuilder.UpdateData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "AvgValue", "CreatedDate", "MaxValue", "MinValue", "ModifiedDate" },
                values: new object[] { 57.45f, new DateTime(2024, 6, 3, 0, 31, 8, 563, DateTimeKind.Local).AddTicks(9985), 96.9f, 18f, new DateTime(2024, 6, 3, 0, 31, 8, 563, DateTimeKind.Local).AddTicks(9986) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2466), new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2510) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2515), new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2516) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2519), new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2520) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2522), new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2523) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2526), new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2527) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2531), new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2532) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2534), new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2535) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2537), new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2539) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2541), new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2542) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2545), new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2546) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2549), new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2550) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2552), new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2553) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2555), new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2557) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2559), new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2560) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2562), new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2563) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2565), new DateTime(2024, 6, 3, 0, 31, 8, 565, DateTimeKind.Local).AddTicks(2567) });

            migrationBuilder.UpdateData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "B0004",
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 564, DateTimeKind.Local).AddTicks(6639), new DateTime(2024, 6, 3, 0, 31, 8, 564, DateTimeKind.Local).AddTicks(6640) });

            migrationBuilder.UpdateData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "C1004",
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 564, DateTimeKind.Local).AddTicks(6636), new DateTime(2024, 6, 3, 0, 31, 8, 564, DateTimeKind.Local).AddTicks(6637) });

            migrationBuilder.UpdateData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P0078",
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 564, DateTimeKind.Local).AddTicks(6606), new DateTime(2024, 6, 3, 0, 31, 8, 564, DateTimeKind.Local).AddTicks(6607) });

            migrationBuilder.UpdateData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P0079",
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 564, DateTimeKind.Local).AddTicks(6549), new DateTime(2024, 6, 3, 0, 31, 8, 564, DateTimeKind.Local).AddTicks(6595) });

            migrationBuilder.UpdateData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P007E",
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 564, DateTimeKind.Local).AddTicks(6610), new DateTime(2024, 6, 3, 0, 31, 8, 564, DateTimeKind.Local).AddTicks(6611) });

            migrationBuilder.UpdateData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P007F",
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 564, DateTimeKind.Local).AddTicks(6618), new DateTime(2024, 6, 3, 0, 31, 8, 564, DateTimeKind.Local).AddTicks(6619) });

            migrationBuilder.UpdateData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P1004",
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 564, DateTimeKind.Local).AddTicks(6624), new DateTime(2024, 6, 3, 0, 31, 8, 564, DateTimeKind.Local).AddTicks(6626) });

            migrationBuilder.UpdateData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P18D0",
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 564, DateTimeKind.Local).AddTicks(6629), new DateTime(2024, 6, 3, 0, 31, 8, 564, DateTimeKind.Local).AddTicks(6630) });

            migrationBuilder.UpdateData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P18E0",
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 564, DateTimeKind.Local).AddTicks(6621), new DateTime(2024, 6, 3, 0, 31, 8, 564, DateTimeKind.Local).AddTicks(6622) });

            migrationBuilder.UpdateData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P18F0",
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 564, DateTimeKind.Local).AddTicks(6632), new DateTime(2024, 6, 3, 0, 31, 8, 564, DateTimeKind.Local).AddTicks(6633) });

            migrationBuilder.UpdateData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P2004",
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 564, DateTimeKind.Local).AddTicks(6599), new DateTime(2024, 6, 3, 0, 31, 8, 564, DateTimeKind.Local).AddTicks(6600) });

            migrationBuilder.UpdateData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P2036",
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 564, DateTimeKind.Local).AddTicks(6614), new DateTime(2024, 6, 3, 0, 31, 8, 564, DateTimeKind.Local).AddTicks(6615) });

            migrationBuilder.UpdateData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P3000",
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 564, DateTimeKind.Local).AddTicks(6602), new DateTime(2024, 6, 3, 0, 31, 8, 564, DateTimeKind.Local).AddTicks(6604) });

            migrationBuilder.UpdateData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "U1004",
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 6, 3, 0, 31, 8, 564, DateTimeKind.Local).AddTicks(6642), new DateTime(2024, 6, 3, 0, 31, 8, 564, DateTimeKind.Local).AddTicks(6644) });

            migrationBuilder.InsertData(
                table: "TroubleCodes",
                columns: new[] { "ProblemCode", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "ProblemDescription", "Severity" },
                values: new object[] { "p0000", null, new DateTime(2024, 6, 3, 0, 31, 8, 564, DateTimeKind.Local).AddTicks(6646), null, new DateTime(2024, 6, 3, 0, 31, 8, 564, DateTimeKind.Local).AddTicks(6647), "No Truble Code", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "p0000");

            migrationBuilder.UpdateData(
                table: "CarSystems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 415, DateTimeKind.Local).AddTicks(1153), new DateTime(2024, 5, 1, 15, 53, 34, 415, DateTimeKind.Local).AddTicks(1197) });

            migrationBuilder.UpdateData(
                table: "CarSystems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 415, DateTimeKind.Local).AddTicks(1202), new DateTime(2024, 5, 1, 15, 53, 34, 415, DateTimeKind.Local).AddTicks(1203) });

            migrationBuilder.UpdateData(
                table: "CarSystems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 415, DateTimeKind.Local).AddTicks(1205), new DateTime(2024, 5, 1, 15, 53, 34, 415, DateTimeKind.Local).AddTicks(1207) });

            migrationBuilder.UpdateData(
                table: "CarSystems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 415, DateTimeKind.Local).AddTicks(1209), new DateTime(2024, 5, 1, 15, 53, 34, 415, DateTimeKind.Local).AddTicks(1210) });

            migrationBuilder.UpdateData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "AvgValue", "CreatedDate", "MaxValue", "MinValue", "ModifiedDate", "Unit" },
                values: new object[] { 2.5f, new DateTime(2024, 5, 1, 15, 53, 34, 416, DateTimeKind.Local).AddTicks(4366), 4.5f, 0.5f, new DateTime(2024, 5, 1, 15, 53, 34, 416, DateTimeKind.Local).AddTicks(4402), "volts" });

            migrationBuilder.UpdateData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "AvgValue", "CreatedDate", "MaxValue", "MinValue", "ModifiedDate", "SensorName", "Unit" },
                values: new object[] { 2.5f, new DateTime(2024, 5, 1, 15, 53, 34, 416, DateTimeKind.Local).AddTicks(4406), 5f, 0f, new DateTime(2024, 5, 1, 15, 53, 34, 416, DateTimeKind.Local).AddTicks(4407), "Fuel Level", "volts" });

            migrationBuilder.UpdateData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "AvgValue", "CreatedDate", "MaxValue", "MinValue", "ModifiedDate", "SensorName", "Unit" },
                values: new object[] { 90.65f, new DateTime(2024, 5, 1, 15, 53, 34, 416, DateTimeKind.Local).AddTicks(4410), 101.3f, 80f, new DateTime(2024, 5, 1, 15, 53, 34, 416, DateTimeKind.Local).AddTicks(4412), "Barometric Pressure", "kPa" });

            migrationBuilder.UpdateData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "AvgValue", "CreatedDate", "MaxValue", "MinValue", "ModifiedDate" },
                values: new object[] { 0f, new DateTime(2024, 5, 1, 15, 53, 34, 416, DateTimeKind.Local).AddTicks(4415), 40f, -40f, new DateTime(2024, 5, 1, 15, 53, 34, 416, DateTimeKind.Local).AddTicks(4416) });

            migrationBuilder.UpdateData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "AvgValue", "CreatedDate", "MaxValue", "MinValue", "ModifiedDate", "SensorName", "Unit" },
                values: new object[] { 4.5f, new DateTime(2024, 5, 1, 15, 53, 34, 416, DateTimeKind.Local).AddTicks(4419), 5f, 4f, new DateTime(2024, 5, 1, 15, 53, 34, 416, DateTimeKind.Local).AddTicks(4420), "MAF (Mass Air Flow)", "volts" });

            migrationBuilder.UpdateData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "AvgValue", "CreatedDate", "MaxValue", "MinValue", "ModifiedDate" },
                values: new object[] { 140f, new DateTime(2024, 5, 1, 15, 53, 34, 416, DateTimeKind.Local).AddTicks(4424), 250f, 30f, new DateTime(2024, 5, 1, 15, 53, 34, 416, DateTimeKind.Local).AddTicks(4425) });

            migrationBuilder.UpdateData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "AvgValue", "CreatedDate", "MaxValue", "MinValue", "ModifiedDate" },
                values: new object[] { 75f, new DateTime(2024, 5, 1, 15, 53, 34, 416, DateTimeKind.Local).AddTicks(4428), 112f, 37f, new DateTime(2024, 5, 1, 15, 53, 34, 416, DateTimeKind.Local).AddTicks(4429) });

            migrationBuilder.UpdateData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "AvgValue", "CreatedDate", "MaxValue", "MinValue", "ModifiedDate" },
                values: new object[] { 45f, new DateTime(2024, 5, 1, 15, 53, 34, 416, DateTimeKind.Local).AddTicks(4432), 100f, 10f, new DateTime(2024, 5, 1, 15, 53, 34, 416, DateTimeKind.Local).AddTicks(4433) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5828), new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5857) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5860), new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5862) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5864), new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5865) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5867), new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5868) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5871), new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5872) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5876), new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5877) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5879), new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5880) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5882), new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5884) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5886), new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5887) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5890), new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5891) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5893), new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5895) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5897), new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5898) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5900), new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5902) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5904), new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5905) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5907), new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5908) });

            migrationBuilder.UpdateData(
                table: "TroubleCodeLinks",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5910), new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(5911) });

            migrationBuilder.UpdateData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "B0004",
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(922), new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(924) });

            migrationBuilder.UpdateData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "C1004",
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(918), new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(920) });

            migrationBuilder.UpdateData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P0078",
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(844), new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(845) });

            migrationBuilder.UpdateData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P0079",
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(799), new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(832) });

            migrationBuilder.UpdateData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P007E",
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(887), new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(888) });

            migrationBuilder.UpdateData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P007F",
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(896), new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(897) });

            migrationBuilder.UpdateData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P1004",
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(904), new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(906) });

            migrationBuilder.UpdateData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P18D0",
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(909), new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(911) });

            migrationBuilder.UpdateData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P18E0",
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(900), new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(901) });

            migrationBuilder.UpdateData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P18F0",
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(914), new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(915) });

            migrationBuilder.UpdateData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P2004",
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(837), new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(838) });

            migrationBuilder.UpdateData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P2036",
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(892), new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(893) });

            migrationBuilder.UpdateData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "P3000",
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(840), new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(841) });

            migrationBuilder.UpdateData(
                table: "TroubleCodes",
                keyColumn: "ProblemCode",
                keyValue: "U1004",
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(927), new DateTime(2024, 5, 1, 15, 53, 34, 417, DateTimeKind.Local).AddTicks(929) });
        }
    }
}
