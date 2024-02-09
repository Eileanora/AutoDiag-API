using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntelligentDiagnostician.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Changetablesnames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parameters_SystemCars_CarSystemId",
                table: "Parameters");

            migrationBuilder.DropForeignKey(
                name: "FK_Readings_Parameters_SensorId",
                table: "Readings");

            migrationBuilder.DropForeignKey(
                name: "FK_Readings_SystemCars_CarSystemId",
                table: "Readings");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Role_RoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SystemCars",
                table: "SystemCars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parameters",
                table: "Parameters");

            migrationBuilder.RenameTable(
                name: "SystemCars",
                newName: "CarSystems");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "Parameters",
                newName: "Sensors");

            migrationBuilder.RenameIndex(
                name: "IX_Parameters_CarSystemId",
                table: "Sensors",
                newName: "IX_Sensors_CarSystemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarSystems",
                table: "CarSystems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sensors",
                table: "Sensors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Readings_CarSystems_CarSystemId",
                table: "Readings",
                column: "CarSystemId",
                principalTable: "CarSystems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Readings_Sensors_SensorId",
                table: "Readings",
                column: "SensorId",
                principalTable: "Sensors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sensors_CarSystems_CarSystemId",
                table: "Sensors",
                column: "CarSystemId",
                principalTable: "CarSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Readings_CarSystems_CarSystemId",
                table: "Readings");

            migrationBuilder.DropForeignKey(
                name: "FK_Readings_Sensors_SensorId",
                table: "Readings");

            migrationBuilder.DropForeignKey(
                name: "FK_Sensors_CarSystems_CarSystemId",
                table: "Sensors");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sensors",
                table: "Sensors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarSystems",
                table: "CarSystems");

            migrationBuilder.RenameTable(
                name: "Sensors",
                newName: "Parameters");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "CarSystems",
                newName: "SystemCars");

            migrationBuilder.RenameIndex(
                name: "IX_Sensors_CarSystemId",
                table: "Parameters",
                newName: "IX_Parameters_CarSystemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parameters",
                table: "Parameters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SystemCars",
                table: "SystemCars",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parameters_SystemCars_CarSystemId",
                table: "Parameters",
                column: "CarSystemId",
                principalTable: "SystemCars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Readings_Parameters_SensorId",
                table: "Readings",
                column: "SensorId",
                principalTable: "Parameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Readings_SystemCars_CarSystemId",
                table: "Readings",
                column: "CarSystemId",
                principalTable: "SystemCars",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Role_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
