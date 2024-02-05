using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntelligentDiagnostics.DAL.Migrations
{
    /// <inheritdoc />
    public partial class removesystemforeignkeyfromreading : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrimaryKeyBaseEntity_PrimaryKeyBaseEntity_CarSystemId",
                table: "PrimaryKeyBaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_PrimaryKeyBaseEntity_PrimaryKeyBaseEntity_ParameterId",
                table: "PrimaryKeyBaseEntity");

            migrationBuilder.RenameColumn(
                name: "ParameterId",
                table: "PrimaryKeyBaseEntity",
                newName: "SensorId");

            migrationBuilder.RenameIndex(
                name: "IX_PrimaryKeyBaseEntity_ParameterId",
                table: "PrimaryKeyBaseEntity",
                newName: "IX_PrimaryKeyBaseEntity_SensorId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrimaryKeyBaseEntity_PrimaryKeyBaseEntity_CarSystemId",
                table: "PrimaryKeyBaseEntity",
                column: "CarSystemId",
                principalTable: "PrimaryKeyBaseEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrimaryKeyBaseEntity_PrimaryKeyBaseEntity_SensorId",
                table: "PrimaryKeyBaseEntity",
                column: "SensorId",
                principalTable: "PrimaryKeyBaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrimaryKeyBaseEntity_PrimaryKeyBaseEntity_CarSystemId",
                table: "PrimaryKeyBaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_PrimaryKeyBaseEntity_PrimaryKeyBaseEntity_SensorId",
                table: "PrimaryKeyBaseEntity");

            migrationBuilder.RenameColumn(
                name: "SensorId",
                table: "PrimaryKeyBaseEntity",
                newName: "ParameterId");

            migrationBuilder.RenameIndex(
                name: "IX_PrimaryKeyBaseEntity_SensorId",
                table: "PrimaryKeyBaseEntity",
                newName: "IX_PrimaryKeyBaseEntity_ParameterId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrimaryKeyBaseEntity_PrimaryKeyBaseEntity_CarSystemId",
                table: "PrimaryKeyBaseEntity",
                column: "CarSystemId",
                principalTable: "PrimaryKeyBaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrimaryKeyBaseEntity_PrimaryKeyBaseEntity_ParameterId",
                table: "PrimaryKeyBaseEntity",
                column: "ParameterId",
                principalTable: "PrimaryKeyBaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
