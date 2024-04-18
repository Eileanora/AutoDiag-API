using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntelligentDiagnostician.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdReadingRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Readings_AspNetUsers_UserId",
                table: "Readings");

            migrationBuilder.RenameColumn(
                name: "ReadingValue",
                table: "Readings",
                newName: "Value");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Readings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Readings_AspNetUsers_UserId",
                table: "Readings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Readings_AspNetUsers_UserId",
                table: "Readings");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Readings",
                newName: "ReadingValue");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Readings",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Readings_AspNetUsers_UserId",
                table: "Readings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
