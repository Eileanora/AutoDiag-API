using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntelligentDiagnostics.DAL.Migrations
{
    /// <inheritdoc />
    public partial class adduserreadingparametertables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "parameters",
                columns: table => new
                {
                    ParameterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParameterName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parameters", x => x.ParameterId);
                });

            migrationBuilder.CreateTable(
                name: "readings",
                columns: table => new
                {
                    ReadingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReadingValue = table.Column<int>(type: "int", nullable: false),
                    ReadingDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SystemCarId = table.Column<int>(type: "int", nullable: false),
                    ParameterId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_readings", x => x.ReadingId);
                    table.ForeignKey(
                        name: "FK_readings_parameters_ParameterId",
                        column: x => x.ParameterId,
                        principalTable: "parameters",
                        principalColumn: "ParameterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_readings_systemCars_SystemCarId",
                        column: x => x.SystemCarId,
                        principalTable: "systemCars",
                        principalColumn: "SystemCarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_readings_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_readings_ParameterId",
                table: "readings",
                column: "ParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_readings_SystemCarId",
                table: "readings",
                column: "SystemCarId");

            migrationBuilder.CreateIndex(
                name: "IX_readings_UserId",
                table: "readings",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "readings");

            migrationBuilder.DropTable(
                name: "parameters");
        }
    }
}
