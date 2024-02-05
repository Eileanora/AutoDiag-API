using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntelligentDiagnostics.DAL.Migrations
{
    /// <inheritdoc />
    public partial class createsystemsensorrelation1m : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sensor_CarSystemId",
                table: "PrimaryKeyBaseEntity",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrimaryKeyBaseEntity_Sensor_CarSystemId",
                table: "PrimaryKeyBaseEntity",
                column: "Sensor_CarSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrimaryKeyBaseEntity_PrimaryKeyBaseEntity_Sensor_CarSystemId",
                table: "PrimaryKeyBaseEntity",
                column: "Sensor_CarSystemId",
                principalTable: "PrimaryKeyBaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrimaryKeyBaseEntity_PrimaryKeyBaseEntity_Sensor_CarSystemId",
                table: "PrimaryKeyBaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_PrimaryKeyBaseEntity_Sensor_CarSystemId",
                table: "PrimaryKeyBaseEntity");

            migrationBuilder.DropColumn(
                name: "Sensor_CarSystemId",
                table: "PrimaryKeyBaseEntity");
        }
    }
}
